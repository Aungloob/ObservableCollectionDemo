using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ObservableCollectionDemo
{
    [Serializable()]
    [XmlType("account")]
    public class Account
    {
        private bool _enable = true;        
        [XmlAttribute("enable")]
        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }

        private string _name = string.Empty;
        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _key = string.Empty;
        [XmlAttribute("key")]
        [ReadOnly(true)]
        public string AccountKey
        {
            get { return _key; }
            set { _key = value; }
        }
    }
}
