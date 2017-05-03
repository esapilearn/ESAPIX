﻿#region

using System;
using System.Collections;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Facade

{
    /// <summary>
    ///     This class is responsible for creating VMS types without knowing anything about VMS classes (not dependent)
    /// </summary>
    public class VMSConstructor
    {
        public static Func<object, object, string, dynamic> ConstructScriptContextFunc0 = null;
        public static Func<double, double, double, dynamic> ConstructVVectorFunc0 = null;

        public static Func<dynamic, double, double, double, double, double, double, dynamic>
            ConstructAxisAlignedMarginsFunc0 = null;

        public static Func<string, string, dynamic> ConstructStructureCodeInfoFunc0 = null;
        public static Func<dynamic, dynamic, BitArray, dynamic> ConstructSegmentProfileFunc0 = null;
        public static Func<dynamic, bool, dynamic> ConstructSegmentProfilePointFunc0 = null;
        public static Func<double, string, dynamic> ConstructDoseValueFunc0 = null;
        public static Func<double, dynamic, dynamic> ConstructDoseValueFunc1 = null;
        public static Func<dynamic, dynamic, double[], dynamic> ConstructLineProfileFunc0 = null;
        public static Func<dynamic, double, dynamic> ConstructProfilePointFunc0 = null;
        public static Func<dynamic, dynamic, double[], dynamic, dynamic> ConstructDoseProfileFunc0 = null;
        public static Func<dynamic, double, string, dynamic> ConstructDVHPointFunc0 = null;
        public static Func<dynamic, dynamic, dynamic, dynamic, dynamic> ConstructVRectFunc0 = null;
        public static Func<double, dynamic, dynamic> ConstructMetersetValueFunc0 = null;
        public static Func<float[,], double, double, dynamic> ConstructFluenceFunc0 = null;
        public static Func<float[,], double, double, string, dynamic> ConstructFluenceFunc1 = null;
        public static Func<dynamic, dynamic, double[], string, dynamic> ConstructImageProfileFunc0 = null;
        public static Func<bool, dynamic> ConstructLMCVOptionsFunc0 = null;
        public static Func<bool, bool, dynamic> ConstructSmartLMCOptionsFunc0 = null;
        public static Func<int, dynamic> ConstructLMCMSSOptionsFunc0 = null;
        public static Func<int, dynamic, int, dynamic, string, dynamic> ConstructOptimizationOptionsIMRTFunc0 = null;

        public static Func<int, dynamic, dynamic, dynamic, string, dynamic> ConstructOptimizationOptionsIMRTFunc1 =
            null;

        public static Func<int, dynamic, dynamic, string, dynamic> ConstructOptimizationOptionsIMRTFunc2 = null;
        public static Func<dynamic, string, dynamic> ConstructOptimizationOptionsVMATFunc0 = null;
        public static Func<dynamic, string, dynamic> ConstructOptimizationOptionsVMATFunc1 = null;
        public static Func<int, string, dynamic> ConstructOptimizationOptionsVMATFunc2 = null;
        public static Func<dynamic, dynamic, int, string, dynamic> ConstructOptimizationOptionsVMATFunc3 = null;
        public static Func<dynamic, dynamic> ConstructOptimizationOptionsVMATFunc4 = null;

        public static Func<string, string, int, string, string, dynamic> ConstructExternalBeamMachineParametersFunc0 =
            null;

        internal static dynamic ConstructScriptContext(object context, object user, string appName)
        {
            if (ConstructScriptContextFunc0 == null)
                throw new NullReferenceException(
                    "The function ConstructScriptContextFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return ConstructScriptContextFunc0(context, user, appName);
            });
        }

        internal static dynamic ConstructVVector(double xi, double yi, double zi)
        {
            if (ConstructVVectorFunc0 == null)
                throw new NullReferenceException(
                    "The function ConstructVVectorFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc => { return ConstructVVectorFunc0(xi, yi, zi); });
        }

        internal static dynamic ConstructStructureCodeInfo(string codingScheme, string code)
        {
            if (ConstructStructureCodeInfoFunc0 == null)
                throw new NullReferenceException(
                    "The function ConstructStructureCodeInfoFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return ConstructStructureCodeInfoFunc0(codingScheme, code);
            });
        }


        internal static dynamic ConstructDoseValue(double value, string unitName)
        {
            if (ConstructDoseValueFunc0 == null)
                throw new NullReferenceException(
                    "The function ConstructDoseValueFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return ConstructDoseValueFunc0(value, unitName);
            });
        }

        internal static dynamic ConstructDoseValue(double value, DoseValue.DoseUnit unit)
        {
            if (ConstructDoseValueFunc1 == null)
                throw new NullReferenceException(
                    "The function ConstructDoseValueFunc1 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc => { return ConstructDoseValueFunc1(value, unit); });
        }


        internal static dynamic ConstructVRect<T>(T x1, T y1, T x2, T y2)
        {
            if (ConstructVRectFunc0 == null)
                throw new NullReferenceException(
                    "The function ConstructVRectFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc => { return ConstructVRectFunc0(x1, y1, x2, y2); });
        }

        internal static dynamic ConstructMetersetValue(double value, DosimeterUnit unit)
        {
            if (ConstructMetersetValueFunc0 == null)
                throw new NullReferenceException(
                    "The function ConstructMetersetValueFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return ConstructMetersetValueFunc0(value, unit);
            });
        }

        internal static dynamic ConstructFluence(float[,] fluenceMatrix, double xOrigin, double yOrigin)
        {
            if (ConstructFluenceFunc0 == null)
                throw new NullReferenceException(
                    "The function ConstructFluenceFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return ConstructFluenceFunc0(fluenceMatrix, xOrigin, yOrigin);
            });
        }

        internal static dynamic ConstructFluence(float[,] fluenceMatrix, double xOrigin, double yOrigin, string mlcId)
        {
            if (ConstructFluenceFunc1 == null)
                throw new NullReferenceException(
                    "The function ConstructFluenceFunc1 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return ConstructFluenceFunc1(fluenceMatrix, xOrigin, yOrigin, mlcId);
            });
        }

        internal static dynamic ConstructLMCVOptions(bool fixedJaws)
        {
            if (ConstructLMCVOptionsFunc0 == null)
                throw new NullReferenceException(
                    "The function ConstructLMCVOptionsFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc => { return ConstructLMCVOptionsFunc0(fixedJaws); });
        }

        internal static dynamic ConstructSmartLMCOptions(bool fixedFieldBorders, bool jawTracking)
        {
            if (ConstructSmartLMCOptionsFunc0 == null)
                throw new NullReferenceException(
                    "The function ConstructSmartLMCOptionsFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return ConstructSmartLMCOptionsFunc0(fixedFieldBorders, jawTracking);
            });
        }

        internal static dynamic ConstructLMCMSSOptions(int numberOfIterations)
        {
            if (ConstructLMCMSSOptionsFunc0 == null)
                throw new NullReferenceException(
                    "The function ConstructLMCMSSOptionsFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return ConstructLMCMSSOptionsFunc0(numberOfIterations);
            });
        }


        internal static dynamic ConstructOptimizationOptionsVMAT(int numberOfCycles, string mlcId)
        {
            if (ConstructOptimizationOptionsVMATFunc2 == null)
                throw new NullReferenceException(
                    "The function ConstructOptimizationOptionsVMATFunc2 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return ConstructOptimizationOptionsVMATFunc2(numberOfCycles, mlcId);
            });
        }

        internal static dynamic ConstructExternalBeamMachineParameters(string machineId, string energyModeId,
            int doseRate, string techniqueId, string primaryFluenceModeId)
        {
            if (ConstructExternalBeamMachineParametersFunc0 == null)
                throw new NullReferenceException(
                    "The function ConstructExternalBeamMachineParametersFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method.");
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return ConstructExternalBeamMachineParametersFunc0(machineId, energyModeId, doseRate, techniqueId,
                    primaryFluenceModeId);
            });
        }
    }
}