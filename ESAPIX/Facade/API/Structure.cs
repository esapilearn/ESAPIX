#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using X = ESAPIX.Facade.XContext;
using System.Windows.Media.Media3D;

#endregion


namespace ESAPIX.Facade.API
{
    public class Structure : ApiDataObject
    {
        public Structure()
        {
            _client = new ExpandoObject();
        }

        public Structure(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public VVector CenterPoint
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CenterPoint")
                        ? _client.CenterPoint
                        : default(VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue<VVector>(sc => { return local._client.CenterPoint; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CenterPoint = value;
            }
        }

        public System.Windows.Media.Color Color
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Color")
                        ? _client.Color
                        : default(System.Windows.Media.Color);
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>(sc =>
                {
                    return local._client.Color;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Color = value;
            }
        }

        public string DicomType
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DicomType") ? _client.DicomType : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.DicomType; });
            }
            set
            {
                if (_client is ExpandoObject) _client.DicomType = value;
            }
        }

        public bool HasSegment
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("HasSegment") ? _client.HasSegment : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.HasSegment; });
            }
            set
            {
                if (_client is ExpandoObject) _client.HasSegment = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsEmpty") ? _client.IsEmpty : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsEmpty; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsEmpty = value;
            }
        }

        public bool IsHighResolution
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsHighResolution")
                        ? _client.IsHighResolution
                        : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsHighResolution; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsHighResolution = value;
            }
        }

        public System.Windows.Media.Media3D.MeshGeometry3D MeshGeometry
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MeshGeometry")
                        ? _client.MeshGeometry
                        : default(System.Windows.Media.Media3D.MeshGeometry3D);
                var local = this;
                MeshGeometry3D mesh = new MeshGeometry3D();
                Point3D[] points = new Point3D[0];
                Vector3D[] normals = new Vector3D[0];
                int[] indices = new int[0];

                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    points = new Point3D[_client.MeshGeometry.Positions.Count];
                    normals = new Vector3D[_client.MeshGeometry.Normals.Count];
                    indices = new int[_client.MeshGeometry.TriangleIndices.Count];
                    _client.MeshGeometry.Positions.CopyTo(points, 0);
                    _client.MeshGeometry.Normals.CopyTo(normals, 0);
                    _client.MeshGeometry.TriangleIndices.CopyTo(indices, 0);
                });
                mesh.Positions = new Point3DCollection(points);
                return mesh;
            }
            set
            {
                if (_client is ExpandoObject) _client.MeshGeometry = value;
            }
        }

        public int ROINumber
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ROINumber") ? _client.ROINumber : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.ROINumber; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ROINumber = value;
            }
        }

        public SegmentVolume SegmentVolume
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SegmentVolume")
                        ? _client.SegmentVolume
                        : default(SegmentVolume);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.SegmentVolume)) return default(SegmentVolume);
                    return new SegmentVolume(local._client.SegmentVolume);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.SegmentVolume = value;
            }
        }

        public double Volume
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Volume") ? _client.Volume : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Volume; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Volume = value;
            }
        }

        public string Id
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Id") ? _client.Id : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Id = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public void AddContourOnImagePlane(VVector[] contour, int z)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.AddContourOnImagePlane(contour, z); });
        }

        public SegmentVolume And(SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentVolume(local._client.And(other._client));
            });
            return retVal;
        }

        public bool CanConvertToHighResolution()
        {
            var local = this;
            var retVal =
                X.Instance.CurrentContext.GetValue(sc => { return local._client.CanConvertToHighResolution(); });
            return retVal;
        }

        public bool CanSetAssignedHU(out string errorMessage)
        {
            var errorMessage_OUT = default(string);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.CanSetAssignedHU(out errorMessage_OUT);
            });
            errorMessage = errorMessage_OUT;
            return retVal;
        }

        public void ClearAllContoursOnImagePlane(int z)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.ClearAllContoursOnImagePlane(z); });
        }

        public void ConvertToHighResolution()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.ConvertToHighResolution(); });
        }

        public bool GetAssignedHU(out double huValue)
        {
            var huValue_OUT = default(double);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetAssignedHU(out huValue_OUT);
            });
            huValue = huValue_OUT;
            return retVal;
        }

        public VVector[][] GetContoursOnImagePlane(int z)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetContoursOnImagePlane(z); });
            return retVal;
        }

        public int GetNumberOfSeparateParts()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetNumberOfSeparateParts(); });
            return retVal;
        }

        public SegmentProfile GetSegmentProfile(VVector start, VVector stop, BitArray preallocatedBuffer)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetSegmentProfile(start, stop, preallocatedBuffer);
            });
            return retVal;
        }

        public bool IsPointInsideSegment(VVector point)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.IsPointInsideSegment(point);
            });
            return retVal;
        }

        public SegmentVolume Margin(double marginInMM)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentVolume(local._client.Margin(marginInMM));
            });
            return retVal;
        }

        public SegmentVolume Not()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return new SegmentVolume(local._client.Not()); });
            return retVal;
        }

        public SegmentVolume Or(SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentVolume(local._client.Or(other._client));
            });
            return retVal;
        }

        public bool ResetAssignedHU()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.ResetAssignedHU(); });
            return retVal;
        }

        public void SetAssignedHU(double huValue)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.SetAssignedHU(huValue); });
        }

        public SegmentVolume Sub(SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentVolume(local._client.Sub(other._client));
            });
            return retVal;
        }

        public void SubtractContourOnImagePlane(VVector[] contour, int z)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.SubtractContourOnImagePlane(contour, z); });
        }

        public SegmentVolume Xor(SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentVolume(local._client.Xor(other._client));
            });
            return retVal;
        }
    }
}