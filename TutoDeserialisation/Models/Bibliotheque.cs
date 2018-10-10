using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoDeserialisation.Models
{
    public class Bibliotheque
    {
        public List<Livre> Livres;
        public Bibliotheque BibliothequeAdjacente;
        public String Theme;
        public int Taille
        {
            get
            {
                return Livres.Count;
            }
        }

        public Bibliotheque()
        {
            this.Livres = new List<Livre>();
        }

        public void WriteLine()
        {
            Console.WriteLine("Bibliothèque - thème : {0}, taille : {1}", Theme, Taille);
            Console.WriteLine("Contenu : ");
            Livres.ForEach(l => l.WriteLine());
            Console.WriteLine("Fin de contenu");
        }
    }
}
