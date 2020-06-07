using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Specialized;
using System.Xml;
using System.Xml.Schema;

namespace RembyClipper2.Langauge
{
    [Serializable]
    public class ExtendedNVC : IXmlSerializable
    {
        #region Private members
        private NameValueCollection properties;
        #endregion

        #region Constructors
        public ExtendedNVC()
        {
        }

        public ExtendedNVC
            (NameValueCollection properties)
        {
            this.properties = properties;
        }
        #endregion

        #region Properties
        [XmlIgnore]
        public NameValueCollection Properties
        {
            get { return this.properties; }
            set { this.properties = value; }
        }
        #endregion

        #region IXmlSerializable Members
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            this.properties = new NameValueCollection();
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(reader.ReadOuterXml());

            var t = xd["ExtendedNVC"];
            foreach (XmlElement tmp in t)
            {
                this.properties.Add(tmp.Attributes[0].Name, tmp.Attributes[0].Value);
            }

            /*while (reader.MoveToNextAttribute())
                this.properties.Add
                    (reader.Name, reader.Value);
            */
            reader.Read();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            foreach (string key in this.properties.Keys)
            {
                writer.WriteStartElement("property");
                string value = this.properties[key];
                writer.WriteAttributeString(key, value);
                writer.WriteEndElement();
            }
        }
        #endregion
    }
}
