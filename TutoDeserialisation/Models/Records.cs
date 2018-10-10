using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TutoDeserialisation.Models
{

    //[XmlRoot("Records")]
    //public class Records
    //{
    //    [XmlElement("Record")]
    //    public Record Record { get; set; }

    //}

    //public class Record
    //{
    //    [XmlElement("Field")]
    //    public string[] Field { get; set; }

    //    [XmlAttribute]
    //    public int id { get; set; }
    //}


    [XmlRoot("Records")]
    public class Records
    {

        [XmlElement("Record")]
        public string[] Record { get; set; }

        [XmlElement("Field")]
        public string[] Field { get; set; }

    }
}
