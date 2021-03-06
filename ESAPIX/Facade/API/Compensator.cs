#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion


namespace ESAPIX.Facade.API
{
    public class Compensator : ApiDataObject
    {
        public Compensator()
        {
            _client = new ExpandoObject();
        }

        public Compensator(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public AddOnMaterial Material
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Material")
                        ? _client.Material
                        : default(AddOnMaterial);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Material)) return default(AddOnMaterial);
                    return new AddOnMaterial(local._client.Material);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Material = value;
            }
        }

        public Slot Slot
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Slot") ? _client.Slot : default(Slot);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Slot)) return default(Slot);
                    return new Slot(local._client.Slot);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Slot = value;
            }
        }

        public Tray Tray
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Tray") ? _client.Tray : default(Tray);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Tray)) return default(Tray);
                    return new Tray(local._client.Tray);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Tray = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}