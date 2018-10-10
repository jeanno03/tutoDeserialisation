using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoDeserialisation.Models
{
    public class Livre
    {
        public string Titre;

        public Livre()
        {
        }

        public void WriteLine()
        {
            Console.WriteLine("Livre - Titre : {0}", Titre);
        }
    }
}
