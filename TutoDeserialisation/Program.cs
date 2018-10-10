using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using TutoDeserialisation.Method;
using TutoDeserialisation.Models;
using static TutoDeserialisation.Models.Records;

namespace TutoDeserialisation
{
    class Program
    {
        static void Main(string[] args)
        {

                //********Sérialisation d'un object **********************
                Livre li01 = new Livre() { Titre = "Molière" };
                Livre li02 = new Livre() { Titre = "Scalpin" };
                Livre li03 = new Livre() { Titre = "Mortedo" };
                Livre li04 = new Livre() { Titre = "Machin" };
                Livre li05 = new Livre() { Titre = "Médor" };
                List<Livre> livres = new List<Livre>();

                livres.Add(li01);
                livres.Add(li02);
                livres.Add(li03);
                livres.Add(li04);
                livres.Add(li05);

                Bibliotheque bibliothequeAdacente = new Bibliotheque();
                Bibliotheque bibliotheque = new Bibliotheque() { Livres = livres, BibliothequeAdjacente = bibliothequeAdacente, Theme = "Blanc" };
                Console.WriteLine("Test de sérialisation");

                XmlSerializer serializer = new XmlSerializer(typeof(Bibliotheque));

                //Un stream writer permet d'ouvrir un fichier sur le disque
                //source\repos\serialisationXML\serialisationXML\bin\Debug

                using (StreamWriter writer = new StreamWriter("Bibliotheque.xml"))
                {
                    serializer.Serialize(writer, bibliotheque);
                    bibliotheque.WriteLine();
                }

                //********Désérialisation d'un object **********************

                string stringXml =
                    "<?xml version='1.0' encoding='utf-16'?>" +
                    "<User>" +
                    "<ID>1</ID>" +
                    "<name>admin</name>" +
                    "<passwd>MD5:F78B - 5AFD - FAA4 - 7D5S - 2EDB - 99E4 - A19B - FF67</passwd>" +
                    "</User>";

                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.LoadXml(stringXml);
                //Console.WriteLine(xmlDoc.ToString());
                XDocument xdoc = new XDocument();
                xdoc = XDocument.Parse(stringXml);

                Console.WriteLine(xdoc.ToString());

                string rsaString = "<?xml version='1.0' encoding='utf-16'?>" +
                                    "<Record contentId='3537257' levelId='287' levelGuid='6f22f885-b890-4c9e-970b-8d9a9bb58dd5' moduleId='469' parentId='0'>" +
                                    "<Field id='22682' guid='0bfcbb80-2a02-4d02-8984-5cbf348fb493' type='1'>CNT-3537257</Field>" +
                                    "<Field id='22679' guid='ff320dec-379a-4154-83e7-6ef0bbdb606f' type='2'>25</Field>" +
                                    "<Field id='22678' guid='0ae11114-ae06-464f-9e08-b1b68aa5f2b0' type='2'>100</Field>" +
                                    "<Field id='22681' guid='107ce810-0324-4745-8682-ad420a20395c' type='2'>0</Field>" +
                                    "<Field id='22677' guid='d762a559-e32a-45e5-9064-d538c7aacfd0' type='1'>[22679]/[22679]*100</Field>" +
                                    "<Field id='22680' guid='3c19fc58-8517-45e2-94d3-865c98124cf5' type='2'/>" +
                                    "</Record>";

                XDocument xdocRsa = XDocument.Parse(rsaString);
                Console.WriteLine(xdocRsa.ToString());

            Console.WriteLine("---------Deserialisation User-----------");

            GetMethod getMethod = new GetMethod();
            string path = string.Empty;
            string xmlInputData = string.Empty;
            //string xmlOutputData = string.Empty;

            User user = getMethod.Deserialize<User>(stringXml);

            Console.WriteLine("user.Name : " + user.Name);
            Console.WriteLine("---------Deserialisation Record-----------");

            string returnRsaString = getRSACtrl();
         
            Records records = getMethod.Deserialize<Records>(returnRsaString);


            for (int i = 0; i < records.Record.Length; i++)
            {
                Console.WriteLine("record : " + records.Record[i]);
            }

            for (int i = 0; i < records.Field.Length; i++)
            {
                Console.WriteLine("record.Field : " + records.Field[i]);
            }

            Console.WriteLine("record n° 1 : " + records.Record[0]);


            Console.WriteLine("---------End-----------");
                Console.ReadKey();

        }



        private static string getRSACtrl()
        {
            string txt = 
            "<?xml version='1.0' encoding='utf-16'?>" +
            "<Records count='3'>" +
            "<Metadata>" +
            "<FieldDefinitions>" +
            "<FieldDefinition id='22682' guid='0bfcbb80-2a02-4d02-8984-5cbf348fb493' name='Control Name' alias='Control_Name'/>" +
            "<FieldDefinition id='22679' guid='ff320dec-379a-4154-83e7-6ef0bbdb606f' name='Nb Antivirus Installes' alias='Nb_Antivirus_Installes'/>" +
            "<FieldDefinition id='22678' guid='0ae11114-ae06-464f-9e08-b1b68aa5f2b0' name='Nb Postes Travail' alias='Nb_Postes_Travail'/>" +
            "<FieldDefinition id='22681' guid='107ce810-0324-4745-8682-ad420a20395c' name='Exploitation Vuln' alias='Exploitation_Vuln'/>" +
            "<FieldDefinition id='22677' guid='d762a559-e32a-45e5-9064-d538c7aacfd0' name='FormuleToApply' alias='FormuleToApply'/>" +
            "<FieldDefinition id='22680' guid='3c19fc58-8517-45e2-94d3-865c98124cf5' name='Pourcentage Conformite' alias='Pourcentage_Conformite'/>" +
            "</FieldDefinitions>" +
            "</Metadata>" +
            "<LevelCounts>" +
            "<LevelCount id='287' guid='6f22f885-b890-4c9e-970b-8d9a9bb58dd5' count='3' />" +
            "</LevelCounts>" +
            "<Record contentId='3537257' levelId='287' levelGuid='6f22f885-b890-4c9e-970b-8d9a9bb58dd5' moduleId='469' parentId='0'>" +
            "<Field id='22682' guid='0bfcbb80-2a02-4d02-8984-5cbf348fb493' type='1'>CNT-3537257</Field>" +
            "<Field id='22679' guid='ff320dec-379a-4154-83e7-6ef0bbdb606f' type='2'>25</Field>" +
            "<Field id='22678' guid='0ae11114-ae06-464f-9e08-b1b68aa5f2b0' type='2'>100</Field>" +
            "<Field id='22681' guid='107ce810-0324-4745-8682-ad420a20395c' type='2'>0</Field>" +
            "<Field id='22677' guid='d762a559-e32a-45e5-9064-d538c7aacfd0' type='1'>[22679]/[22679]*100</Field>" +
            "<Field id='22680' guid='3c19fc58-8517-45e2-94d3-865c98124cf5' type='2' />" +
            "</Record>" +
            "<Record contentId='3537258' levelId='287' levelGuid='6f22f885-b890-4c9e-970b-8d9a9bb58dd5' moduleId='469' parentId='0'>" +
            "<Field id='22682' guid='0bfcbb80-2a02-4d02-8984-5cbf348fb493' type='1'>CNT-3537258</Field>" +
            "<Field id='22679' guid='ff320dec-379a-4154-83e7-6ef0bbdb606f' type='2'>0</Field>" +
            "<Field id='22678' guid='0ae11114-ae06-464f-9e08-b1b68aa5f2b0' type='2'>100</Field>" +
            "<Field id='22681' guid='107ce810-0324-4745-8682-ad420a20395c' type='2'>15</Field>" +
            "<Field id='22677' guid='d762a559-e32a-45e5-9064-d538c7aacfd0' type='1'>100-[22681]</Field>" +
            "<Field id='22680' guid='3c19fc58-8517-45e2-94d3-865c98124cf5' type='2' />" +
            "</Record>" +
            "<Record contentId='3537259' levelId='287' levelGuid='6f22f885-b890-4c9e-970b-8d9a9bb58dd5' moduleId='469' parentId='0'>" +
            "<Field id='22682' guid='0bfcbb80-2a02-4d02-8984-5cbf348fb493' type='1'>CNT-3537259</Field>" +
            "<Field id='22679' guid='ff320dec-379a-4154-83e7-6ef0bbdb606f' type='2'>0,4</Field>" +
            "<Field id='22678' guid='0ae11114-ae06-464f-9e08-b1b68aa5f2b0' type='2'>0,6</Field>" +
            "<Field id='22681' guid='107ce810-0324-4745-8682-ad420a20395c' type='2'>5</Field>" +
            "<Field id='22677' guid='d762a559-e32a-45e5-9064-d538c7aacfd0' type='1'>100*([22678]-[22679])-[22681]</Field>" +
            "<Field id='22680' guid='3c19fc58-8517-45e2-94d3-865c98124cf5' type='2' />" +
            "</Record>" +
            "</Records>";
            return txt;
        }

    }
}
