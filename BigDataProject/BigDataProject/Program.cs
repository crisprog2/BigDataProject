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
        public static List<int> numeroarticulos = new List<int>();
        public static List<int> numeropreposiciones = new List<int>();
        public static void datos(int numcap)
        {
            string cadena;
            int numpronombres = 0, numadjetivos = 0, numarticulos=0, numpreposiciones=0;
            Char delimitador = ' ';
            string[] capitulo = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\DON QUIJOTE\CAPITULO " + numcap+".txt", Encoding.UTF8);
            string[] pronombres = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\pronombres.txt", Encoding.UTF8);
            string[] adjetivos = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\adjetivos.txt", Encoding.UTF8);
            string[] preposiciones=System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\preposiciones.txt", Encoding.UTF8);
            string[] articulos = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\articulos.txt", Encoding.UTF8);
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
                    foreach (string articulo in articulos)
                    {
                        if (palabra.Equals(articulo))
                        {
                            numarticulos++;
                        }
                    }
                    foreach (string preposicion in preposiciones)
                    {
                        if (palabra.Equals(preposicion))
                        {
                            numpreposiciones++;
                        }
                    }
                }
            }
            numeroadjetivos.Add(numadjetivos);
            numeropronombres.Add(numpronombres);
            numeroarticulos.Add(numarticulos);
            numeropreposiciones.Add(numpreposiciones);
        }

        static void Main(string[] args)
        {
            int numcapitulo, totalpronombre=0, totaladjetivo=0, totalarticulo=0, totalpreposicion=0;
            List<Capitulo> pronombreCapitulo = new List<Capitulo>();
            List<Capitulo> adjetivoCapitulo = new List<Capitulo>();
            List<Capitulo> articuloCapitulo = new List<Capitulo>();
            List<Capitulo> preposicionCapitulo = new List<Capitulo>();
            Capitulo pronombre, adjetivos, articulo, preposicion;
            for(int i = 1; i <= 35; i++)
            {
                datos(i);
            }
            
            for(int i = 0; i < 35; i++)
            {
                numcapitulo = i + 1;
                pronombre = new Capitulo { capitulo = "Capitulo "+ numcapitulo, numerodatos = numeropronombres[i] };
                adjetivos = new Capitulo { capitulo = "Capitulo " + numcapitulo, numerodatos = numeroadjetivos[i] };
                articulo = new Capitulo { capitulo = "Capitulo " + numcapitulo, numerodatos = numeroarticulos[i] };
                preposicion = new Capitulo { capitulo = "Capitulo " + numcapitulo, numerodatos = numeropreposiciones[i] };
                pronombreCapitulo.Add(pronombre);
                adjetivoCapitulo.Add(adjetivos);
                articuloCapitulo.Add(articulo);
                preposicionCapitulo.Add(preposicion);

            }

            foreach(int suma in numeropronombres)
            {
                totalpronombre = totalpronombre + suma;
            }
            foreach(int suma in numeroadjetivos)
            {
                totaladjetivo = totaladjetivo + suma;
            }
            foreach(int suma in numeroarticulos)
            {
                totalarticulo = totalarticulo + suma;
            }
            foreach(int suma in numeropreposiciones)
            {
                totalpreposicion = totalpreposicion + suma;
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
            var jsonarticulos = new Articulos
            {
                totalarticulos = totalarticulo,
                Articulo = articuloCapitulo
            };
            var jsonpreposiciones = new Preposiciones
            {
                totalpreposiciones = totalpreposicion,
                Preposicion = preposicionCapitulo
            };
            string json= JsonConvert.SerializeObject(jsonpronombres);
            string json2 = JsonConvert.SerializeObject(jsonadjetivos);
            string json3 = JsonConvert.SerializeObject(jsonarticulos);
            string json4 = JsonConvert.SerializeObject(jsonpreposiciones);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonpronombres.json", json);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonadjetivos.json", json2);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonarticulos.json", json3);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonpreposiciones.json", json4);
            Console.WriteLine("Fin del programa");
            Console.ReadLine();
        }
    }
}
