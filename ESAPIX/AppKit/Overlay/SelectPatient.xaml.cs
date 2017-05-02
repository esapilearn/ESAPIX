﻿#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

#endregion

namespace ESAPIX.AppKit.Overlay
{
    /// <summary>
    ///     Interaction logic for SelectPatient.xaml, helps to pick a patient when using a StandAloneContext. Will display at
    ///     the top of the designed window
    /// </summary>
    public partial class SelectPatient : Page, INotifyPropertyChanged
    {
        private readonly StandAloneContext _app;
        private readonly Dispatcher _disp;
        private string _selCourse;

        private string _selectedPlanItem;

        public SelectPatient(StandAloneContext app)
        {
            _disp = Dispatcher.CurrentDispatcher;
            InitializeComponent();
            _app = app;
            DataContext = this;
            patientContextMenu.Visibility = Visibility.Visible;
            hideContextButton.Visibility = Visibility.Visible;
            showContextButton.Visibility = Visibility.Collapsed;
            Courses = new ObservableCollection<string>();
            PlanItems = new ObservableCollection<string>();
        }

        public string PatientId { get; set; }
        public string Status { get; set; }
        public ObservableCollection<string> Courses { get; set; }
        public ObservableCollection<string> PlanItems { get; set; }

        public string SelectedCourse
        {
            get { return _selCourse; }
            set
            {
                _selCourse = value;
                var plans = new List<string>();
                Action asyncA = async () =>
                {
                    //Call VMS
                    await Task.Run(() =>
                    {
                        var course = _app.Patient.Courses.FirstOrDefault(c => c.Id == _selCourse);
                        _app.SetCourse(course);
                        UpdateStatus(string.Format("Current Context is {0}, {1} | {2}", _app.Patient.LastName,
                            _app.Patient.FirstName, "Loading plans...."));
                        plans = course != null ? course.PlanSetups.Select(ps => ps.Id).ToList() : new List<string>();
                        UpdateStatus(string.Format("Current Context is {0}, {1} | {2}", _app.Patient.LastName,
                            _app.Patient.FirstName, _app.Patient.Id));
                    });

                    //Update UI
                    _disp.Invoke(() =>
                    {
                        PlanItems.Clear();
                        plans.ForEach(PlanItems.Add);
                        SelectedPlanItem = PlanItems.FirstOrDefault();
                        OnPropertyChanged("SelectedPlanItem");
                        OnPropertyChanged("SelectedCourse");
                    });
                };
                asyncA.Invoke();
            }
        }

        public string SelectedPlanItem
        {
            get { return _selectedPlanItem; }
            set
            {
                _selectedPlanItem = value;
                if (value != null)
                    _app.Thread.InvokeAsync(() =>
                    {
                        var plan = _app.Course.PlanSetups.FirstOrDefault(ps => ps.Id == value);
                        _app.SetPlanSetup(plan);
                    });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus("Searching...");
            await UpdatePatient();
        }

        public async Task UpdatePatient()
        {
            if (_app != null)
                await _app.Thread.InvokeAsync(() =>
                {
                    if (_app.Patient != null && _app.Patient.IsLive)
                        _app.ClosePatient();
                    if (_app.SetPatient(PatientId))
                    {
                        var courses = _app.Patient.Courses.Select(c => c.Id).ToList();
                        _disp.Invoke(() =>
                        {
                            Courses.Clear();
                            courses.ForEach(Courses.Add);
                        });
                        UpdateStatus(string.Format("Current Context is {0}, {1} | {2}", _app.Patient.LastName,
                            _app.Patient.FirstName, _app.Patient.Id));
                        SelectedCourse = Courses.FirstOrDefault();
                        OnPropertyChanged("Courses");
                        OnPropertyChanged("SelectedCourse");
                        OnPropertyChanged("Status");
                    }
                    else
                    {
                        UpdateStatus("Patient not found!");
                    }
                });
        }

        private void UpdateStatus(string p)
        {
            Status = p;
            OnPropertyChanged("Status");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ShowPatientContext_Click(object sender, RoutedEventArgs e)
        {
            patientContextMenu.Visibility = Visibility.Visible;
            hideContextButton.Visibility = Visibility.Visible;
            showContextButton.Visibility = Visibility.Collapsed;
        }

        private void HidePatientContext_Click(object sender, RoutedEventArgs e)
        {
            patientContextMenu.Visibility = Visibility.Collapsed;
            hideContextButton.Visibility = Visibility.Collapsed;
            showContextButton.Visibility = Visibility.Visible;
        }
    }
}