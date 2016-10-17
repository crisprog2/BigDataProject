using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BigDataProject
{
    class Program
    {
        public static List<int> numeropronombres = new List<int>();
        public static List<int> numeroadjetivos = new List<int>();
        public static void datos(int numcap)
        {
            /*Console.WriteLine("**************************************");
            Console.WriteLine("Capitulo " + numcap);
            Console.WriteLine("**************************************");*/
            string cadena;
            int numpronombres = 0, numadjetivos = 0;
            Char delimitador = ' ';
            string[] capitulo = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\DON QUIJOTE\CAPITULO " + numcap+".txt", Encoding.UTF8);
            string[] pronombres = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\pronombres.txt", Encoding.UTF8);
            string[] adjetivos = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\adjetivos.txt", Encoding.UTF8);
            foreach (string line in capitulo)
            {
                cadena = Regex.Replace(line, @"[,-.:()«»¿?;!¡]", "");
                cadena = cadena.ToLower();
                string[] palabras = cadena.Split(delimitador);
                foreach (var palabra in palabras)
                {
                    foreach (string pronombre in pronombres)
                    {
                        if (palabra.Equals(pronombre))
                        {
                            numpronombres++;
                        }
                    }
                    foreach (string adjetivo in adjetivos)
                    {
                        if (palabra.Equals(adjetivo))
                        {
                            numadjetivos++;
                        }
                    }
                }
            }
            numeroadjetivos.Add(numadjetivos);
            numeropronombres.Add(numpronombres);
            /*Console.WriteLine("Numero de pronombres en capitulo: " + numpronombres);
            Console.WriteLine("Numero de adjetivos en capitulo: " + numadjetivos);
            Console.WriteLine("**************************************");
            Console.WriteLine();
            Console.WriteLine();*/
        }

        static void Main(string[] args)
        {
            int numcapitulo, totalpronombre=0, totaladjetivo=0;
            List<Capitulo> pronombreCapitulo = new List<Capitulo>();
            List<Capitulo> adjetivoCapitulo = new List<Capitulo>();
            Capitulo pronombre, adjetivos;
            for(int i = 1; i <= 35; i++)
            {
                datos(i);
            }

            for(int i = 0; i < 35; i++)
            {
                numcapitulo = i + 1;
                pronombre = new Capitulo { capitulo = "Capitulo "+ numcapitulo, numerodatos = numeropronombres[i] };
                adjetivos = new Capitulo { capitulo = "Capitulo " + numcapitulo, numerodatos = numeroadjetivos[i] };
                pronombreCapitulo.Add(pronombre);
                adjetivoCapitulo.Add(adjetivos);

            }

            foreach(int suma in numeropronombres)
            {
                totalpronombre = totalpronombre + suma;
            }
            foreach(int suma in numeroadjetivos)
            {
                totaladjetivo = totaladjetivo + suma;
            }
            var jsonpronombres = new Pronombres
            {
                totalpronombres = totalpronombre,
                Pronombre = pronombreCapitulo
            };
            var jsonadjetivos = new Adjetivos
            {
                totaladjetivos = totaladjetivo,
                adjetivos=adjetivoCapitulo
            };
            string json= JsonConvert.SerializeObject(jsonpronombres);
            string json2 = JsonConvert.SerializeObject(jsonadjetivos);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonpronombres.json", json);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonadjetivos.json", json2);
            Console.ReadLine();
        }
    }
}
