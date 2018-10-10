using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TutoDeserialisation.Models
{
    public class User
    {
        [XmlElement("ID")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("passwd")]
        public string Password { get; set; }

        //public User Deserialize<T>(string input) where User : class
        //{
        //    System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(User));

        //    using (StringReader sr = new StringReader(input))
        //    {
        //        return (User)User.Deserialize(sr);
        //    }

        //}
    }
}
