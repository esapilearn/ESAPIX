﻿#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESAPIX.Facade.API;
using ESAPIX.Interfaces;
using System.Windows.Threading;

#endregion

namespace ESAPIX.AppKit
{
    /// <summary>
    ///     Wraps a VMS application in a way that replicates the ScriptContext class. Can be used for debugging or building two
    ///     sided apps
    /// </summary>
    public class StandAloneContext : IScriptContext, IDisposable
    {
        private readonly Application _app;

        public StandAloneContext(Application app, IVMSThread thread)
        {
            _app = app;
            Thread = thread ?? new AppComThread(false); //Same thread
        }

        public void Dispose()
        {
            _app.Dispose();
        }

        public Course Course { get; private set; }

        public User CurrentUser => _app?.CurrentUser;

        public Image Image => PlanSetup?.StructureSet.Image;

        public Patient Patient { get; private set; }

        public PlanSetup PlanSetup { get; private set; }

        public IEnumerable<PlanSetup> PlansInScope => Course?.PlanSetups;

        public IEnumerable<PlanSum> PlanSumsInScope => Course?.PlanSums;

        public StructureSet StructureSet => PlanSetup?.StructureSet;

        public IVMSThread Thread { get; }

        public Dispatcher UIDispatcher { get; set; }

        /// <summary>
        ///     Creates a new application context and binds it to a new thread
        /// </summary>
        /// <param name="username">VMS username</param>
        /// <param name="password">VMS password</param>
        /// <returns>app context</returns>
        public static StandAloneContext Create(string username, string password)
        {
            var thread = new AppComThread();
            Application app = null;
            thread.Invoke(() => { app = Application.CreateApplication(username, password); });
            return new StandAloneContext(app, thread);
        }

        /// <summary>
        ///     Creates a new application context and binds it to a new thread
        /// </summary>
        /// <param name="username">VMS username</param>
        /// <param name="password">VMS password</param>
        /// <returns>app context</returns>
        public static StandAloneContext CreateSingleThread(string username, string password)
        {
            var thread = new AppComThread(false);
            Application app = null;
            app = Application.CreateApplication(username, password);
            return new StandAloneContext(app, thread);
        }

        public bool SetPatient(string id)
        {
            Patient = _app.OpenPatientById(id);
            var found = Patient.IsLive;
            if (found)
                OnPatientChanged(Patient);
            else
                OnPatientChanged(null);
            return found;
        }

        public async Task<bool> SetPatientAsync(string id)
        {
            Patient = await Task.Run(() => { return _app.OpenPatientById(id); });
            var found = Patient.IsLive;
            if (found)
                OnPatientChanged(Patient);
            else
                OnPatientChanged(null);
            return found;
        }

        public bool SetCourse(Course course)
        {
            Course = course;
            //Notify
            OnCourseChanged(course);
            return Course != null;
        }

        public bool SetPlanSetup(PlanSetup plan)
        {
            PlanSetup = plan;
            //Notify
            OnPlanSetupChanged(plan);
            return PlanSetup != null;
        }

        public void ClosePatient()
        {
            _app.ClosePatient();
            OnPatientChanged(null);
            SetPlanSetup(null);
            SetCourse(null);
        }

        #region CONTEXT CHANGED EVENTS

        public delegate void PatientChangedHandler(Patient newPatient);

        public event PatientChangedHandler PatientChanged;

        public void OnPatientChanged(Patient p)
        {
            PatientChanged?.Invoke(p);
        }

        public delegate void PlanSetupChangedHandler(PlanSetup ps);

        public event PlanSetupChangedHandler PlanSetupChanged;

        public void OnPlanSetupChanged(PlanSetup ps)
        {
            PlanSetupChanged?.Invoke(ps);
        }

        public delegate void CourseChangedHandler(Course c);

        public event CourseChangedHandler CourseChanged;

        public void OnCourseChanged(Course c)
        {
            CourseChanged?.Invoke(c);
        }

        public async Task<T> GetValueAsync<T>(Func<IScriptContext, T> toExecute)
        {
            var result = default(T);
            await Thread.InvokeAsync(() => { result = toExecute(this); });
            return result;
        }

        public T GetValue<T>(Func<IScriptContext, T> toExecute)
        {
            var result = default(T);
            Thread.Invoke(() => { result = toExecute(this); });
            return result;
        }

        #endregion
    }
}