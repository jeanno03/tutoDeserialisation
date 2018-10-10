using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoDeserialisation.Method
{
    public class GetMethod
    {
        //https://www.codeproject.com/Articles/1163664/Convert-XML-to-Csharp-Object
        //excellent tuto
        public T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }



    }
}
