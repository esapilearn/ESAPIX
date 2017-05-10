#region

using System.Dynamic;
using VMS.TPS.Common.Model.Types;
using X = ESAPIX.Facade.XContext;

#endregion


namespace ESAPIX.Facade.API
{
    public class SegmentVolume : SerializableObject
    {
        public SegmentVolume()
        {
            _client = new ExpandoObject();
        }

        public SegmentVolume(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
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

        public SegmentVolume Sub(SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentVolume(local._client.Sub(other._client));
            });
            return retVal;
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