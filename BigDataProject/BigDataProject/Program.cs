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

        public static Letra letraABC;
        public static List<Letra> listaLetra;
        public static GlosarioCapitulo glosarioCap;
        public static List<GlosarioCapitulo> listaGlosarioCap = new List<GlosarioCapitulo>();


        public static List<int> numeropronombres = new List<int>();
        public static List<int> numeroadjetivos = new List<int>();
        public static List<int> numeroarticulos = new List<int>();
        public static List<int> numeropreposiciones = new List<int>();
        public static int[] pronombresxalfabeto = new int[27];
        public static int[] preposicionexsalfabeto = new int[27];
        public static int[] articulosxalfabeto = new int[27];
        public static int[] adjetivosxalfabeto = new int[27];
        public static char[] abecedario = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public static int numeropalabras = 0;
        public static void iniciarVectores()
        {
            for (int i = 0; i < 27; i++)
            {
                pronombresxalfabeto[i] = 0;
                preposicionexsalfabeto[i] = 0;
                articulosxalfabeto[i] = 0;
                adjetivosxalfabeto[i] = 0;
            }
        }
        public static void datos(int numcap)
        {
            listaLetra = new List<Letra>();
            iniciarVectores();
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
                    numeropalabras++;
                    foreach (string pronombre in pronombres)
                    {
                        if (palabra.Equals(pronombre))
                        {
                            numpronombres++;
                            switch (palabra[0])
                            {
                                case 'a':
                                    pronombresxalfabeto[0] = pronombresxalfabeto[0] + 1;
                                    break;
                                case 'b':
                                    pronombresxalfabeto[1] = pronombresxalfabeto[1] + 1;
                                    break;
                                case 'c':
                                    pronombresxalfabeto[2] = pronombresxalfabeto[2] + 1;
                                    break;
                                case 'd':
                                    pronombresxalfabeto[3] = pronombresxalfabeto[3] + 1;
                                    break;
                                case 'e':
                                    pronombresxalfabeto[4] = pronombresxalfabeto[4] + 1;
                                    break;
                                case 'f':
                                    pronombresxalfabeto[5] = pronombresxalfabeto[5] + 1;
                                    break;
                                case 'g':
                                    pronombresxalfabeto[6] = pronombresxalfabeto[6] + 1;
                                    break;
                                case 'h':
                                    pronombresxalfabeto[7] = pronombresxalfabeto[7] + 1;
                                    break;
                                case 'i':
                                    pronombresxalfabeto[8] = pronombresxalfabeto[8] + 1;
                                    break;
                                case 'j':
                                    pronombresxalfabeto[9] = pronombresxalfabeto[9] + 1;
                                    break;
                                case 'k':
                                    pronombresxalfabeto[10] = pronombresxalfabeto[10] + 1;
                                    break;
                                case 'l':
                                    pronombresxalfabeto[11] = pronombresxalfabeto[11] + 1;
                                    break;
                                case 'm':
                                    pronombresxalfabeto[12] = pronombresxalfabeto[12] + 1;
                                    break;
                                case 'n':
                                    pronombresxalfabeto[13] = pronombresxalfabeto[13] + 1;
                                    break;
                                case 'ñ':
                                    pronombresxalfabeto[14] = pronombresxalfabeto[14] + 1;
                                    break;
                                case 'o':
                                    pronombresxalfabeto[15] = pronombresxalfabeto[15] + 1;
                                    break;
                                case 'p':
                                    pronombresxalfabeto[16] = pronombresxalfabeto[16] + 1;
                                    break;
                                case 'q':
                                    pronombresxalfabeto[17] = pronombresxalfabeto[17] + 1;
                                    break;
                                case 'r':
                                    pronombresxalfabeto[18] = pronombresxalfabeto[18] + 1;
                                    break;
                                case 's':
                                    pronombresxalfabeto[19] = pronombresxalfabeto[19] + 1;
                                    break;
                                case 't':
                                    pronombresxalfabeto[20] = pronombresxalfabeto[20] + 1;
                                    break;
                                case 'u':
                                    pronombresxalfabeto[21] = pronombresxalfabeto[21] + 1;
                                    break;
                                case 'v':
                                    pronombresxalfabeto[22] = pronombresxalfabeto[22] + 1;
                                    break;
                                case 'w':
                                    pronombresxalfabeto[23] = pronombresxalfabeto[23] + 1;
                                    break;
                                case 'x':
                                    pronombresxalfabeto[24] = pronombresxalfabeto[24] + 1;
                                    break;
                                case 'y':
                                    pronombresxalfabeto[25] = pronombresxalfabeto[25] + 1;
                                    break;
                                case 'z':
                                    pronombresxalfabeto[26] = pronombresxalfabeto[26] + 1;
                                    break;
                            }
                        }
                    }
                    foreach (string adjetivo in adjetivos)
                    {
                        if (palabra.Equals(adjetivo))
                        {
                            numadjetivos++;
                            switch (palabra[0])
                            {
                                case 'a':
                                    adjetivosxalfabeto[0] = adjetivosxalfabeto[0] + 1;
                                    break;
                                case 'b':
                                    adjetivosxalfabeto[1] = adjetivosxalfabeto[1] + 1;
                                    break;
                                case 'c':
                                    adjetivosxalfabeto[2] = adjetivosxalfabeto[2] + 1;
                                    break;
                                case 'd':
                                    adjetivosxalfabeto[3] = adjetivosxalfabeto[3] + 1;
                                    break;
                                case 'e':
                                    adjetivosxalfabeto[4] = adjetivosxalfabeto[4] + 1;
                                    break;
                                case 'f':
                                    adjetivosxalfabeto[5] = adjetivosxalfabeto[5] + 1;
                                    break;
                                case 'g':
                                    adjetivosxalfabeto[6] = adjetivosxalfabeto[6] + 1;
                                    break;
                                case 'h':
                                    adjetivosxalfabeto[7] = adjetivosxalfabeto[7] + 1;
                                    break;
                                case 'i':
                                    adjetivosxalfabeto[8] = adjetivosxalfabeto[8] + 1;
                                    break;
                                case 'j':
                                    adjetivosxalfabeto[9] = adjetivosxalfabeto[9] + 1;
                                    break;
                                case 'k':
                                    adjetivosxalfabeto[10] = adjetivosxalfabeto[10] + 1;
                                    break;
                                case 'l':
                                    adjetivosxalfabeto[11] = adjetivosxalfabeto[11] + 1;
                                    break;
                                case 'm':
                                    adjetivosxalfabeto[12] = adjetivosxalfabeto[12] + 1;
                                    break;
                                case 'n':
                                    adjetivosxalfabeto[13] = adjetivosxalfabeto[13] + 1;
                                    break;
                                case 'ñ':
                                    adjetivosxalfabeto[14] = adjetivosxalfabeto[14] + 1;
                                    break;
                                case 'o':
                                    adjetivosxalfabeto[15] = adjetivosxalfabeto[15] + 1;
                                    break;
                                case 'p':
                                    adjetivosxalfabeto[16] = adjetivosxalfabeto[16] + 1;
                                    break;
                                case 'q':
                                    adjetivosxalfabeto[17] = adjetivosxalfabeto[17] + 1;
                                    break;
                                case 'r':
                                    adjetivosxalfabeto[18] = adjetivosxalfabeto[18] + 1;
                                    break;
                                case 's':
                                    adjetivosxalfabeto[19] = adjetivosxalfabeto[19] + 1;
                                    break;
                                case 't':
                                    adjetivosxalfabeto[20] = adjetivosxalfabeto[20] + 1;
                                    break;
                                case 'u':
                                    adjetivosxalfabeto[21] = adjetivosxalfabeto[21] + 1;
                                    break;
                                case 'v':
                                    adjetivosxalfabeto[22] = adjetivosxalfabeto[22] + 1;
                                    break;
                                case 'w':
                                    adjetivosxalfabeto[23] = adjetivosxalfabeto[23] + 1;
                                    break;
                                case 'x':
                                    adjetivosxalfabeto[24] = adjetivosxalfabeto[24] + 1;
                                    break;
                                case 'y':
                                    adjetivosxalfabeto[25] = adjetivosxalfabeto[25] + 1;
                                    break;
                                case 'z':
                                    adjetivosxalfabeto[26] = adjetivosxalfabeto[26] + 1;
                                    break;
                            }
                        }
                    }
                    foreach (string articulo in articulos)
                    {
                        if (palabra.Equals(articulo))
                        {
                            numarticulos++;
                            switch (palabra[0])
                            {
                                case 'a':
                                    articulosxalfabeto[0] = articulosxalfabeto[0] + 1;
                                    break;
                                case 'b':
                                    articulosxalfabeto[1] = articulosxalfabeto[1] + 1;
                                    break;
                                case 'c':
                                    articulosxalfabeto[2] = articulosxalfabeto[2] + 1;
                                    break;
                                case 'd':
                                    articulosxalfabeto[3] = articulosxalfabeto[3] + 1;
                                    break;
                                case 'e':
                                    articulosxalfabeto[4] = articulosxalfabeto[4] + 1;
                                    break;
                                case 'f':
                                    articulosxalfabeto[5] = articulosxalfabeto[5] + 1;
                                    break;
                                case 'g':
                                    articulosxalfabeto[6] = articulosxalfabeto[6] + 1;
                                    break;
                                case 'h':
                                    articulosxalfabeto[7] = articulosxalfabeto[7] + 1;
                                    break;
                                case 'i':
                                    articulosxalfabeto[8] = articulosxalfabeto[8] + 1;
                                    break;
                                case 'j':
                                    articulosxalfabeto[9] = articulosxalfabeto[9] + 1;
                                    break;
                                case 'k':
                                    articulosxalfabeto[10] = articulosxalfabeto[10] + 1;
                                    break;
                                case 'l':
                                    articulosxalfabeto[11] = articulosxalfabeto[11] + 1;
                                    break;
                                case 'm':
                                    articulosxalfabeto[12] = articulosxalfabeto[12] + 1;
                                    break;
                                case 'n':
                                    articulosxalfabeto[13] = articulosxalfabeto[13] + 1;
                                    break;
                                case 'ñ':
                                    articulosxalfabeto[14] = articulosxalfabeto[14] + 1;
                                    break;
                                case 'o':
                                    articulosxalfabeto[15] = articulosxalfabeto[15] + 1;
                                    break;
                                case 'p':
                                    articulosxalfabeto[16] = articulosxalfabeto[16] + 1;
                                    break;
                                case 'q':
                                    articulosxalfabeto[17] = articulosxalfabeto[17] + 1;
                                    break;
                                case 'r':
                                    articulosxalfabeto[18] = articulosxalfabeto[18] + 1;
                                    break;
                                case 's':
                                    articulosxalfabeto[19] = articulosxalfabeto[19] + 1;
                                    break;
                                case 't':
                                    articulosxalfabeto[20] = articulosxalfabeto[20] + 1;
                                    break;
                                case 'u':
                                    articulosxalfabeto[21] = articulosxalfabeto[21] + 1;
                                    break;
                                case 'v':
                                    articulosxalfabeto[22] = articulosxalfabeto[22] + 1;
                                    break;
                                case 'w':
                                    articulosxalfabeto[23] = articulosxalfabeto[23] + 1;
                                    break;
                                case 'x':
                                    articulosxalfabeto[24] = articulosxalfabeto[24] + 1;
                                    break;
                                case 'y':
                                    articulosxalfabeto[25] = articulosxalfabeto[25] + 1;
                                    break;
                                case 'z':
                                    articulosxalfabeto[26] = articulosxalfabeto[26] + 1;
                                    break;
                            }
                        }
                    }
                    foreach (string preposicion in preposiciones)
                    {
                        if (palabra.Equals(preposicion))
                        {
                            numpreposiciones++;
                            switch (palabra[0])
                            {
                                case 'a':
                                    preposicionexsalfabeto[0] = preposicionexsalfabeto[0] + 1;
                                    break;
                                case 'b':
                                    preposicionexsalfabeto[1] = preposicionexsalfabeto[1] + 1;
                                    break;
                                case 'c':
                                    preposicionexsalfabeto[2] = preposicionexsalfabeto[2] + 1;
                                    break;
                                case 'd':
                                    preposicionexsalfabeto[3] = preposicionexsalfabeto[3] + 1;
                                    break;
                                case 'e':
                                    preposicionexsalfabeto[4] = preposicionexsalfabeto[4] + 1;
                                    break;
                                case 'f':
                                    preposicionexsalfabeto[5] = preposicionexsalfabeto[5] + 1;
                                    break;
                                case 'g':
                                    preposicionexsalfabeto[6] = preposicionexsalfabeto[6] + 1;
                                    break;
                                case 'h':
                                    preposicionexsalfabeto[7] = preposicionexsalfabeto[7] + 1;
                                    break;
                                case 'i':
                                    preposicionexsalfabeto[8] = preposicionexsalfabeto[8] + 1;
                                    break;
                                case 'j':
                                    preposicionexsalfabeto[9] = preposicionexsalfabeto[9] + 1;
                                    break;
                                case 'k':
                                    preposicionexsalfabeto[10] = preposicionexsalfabeto[10] + 1;
                                    break;
                                case 'l':
                                    preposicionexsalfabeto[11] = preposicionexsalfabeto[11] + 1;
                                    break;
                                case 'm':
                                    preposicionexsalfabeto[12] = preposicionexsalfabeto[12] + 1;
                                    break;
                                case 'n':
                                    preposicionexsalfabeto[13] = preposicionexsalfabeto[13] + 1;
                                    break;
                                case 'ñ':
                                    preposicionexsalfabeto[14] = preposicionexsalfabeto[14] + 1;
                                    break;
                                case 'o':
                                    preposicionexsalfabeto[15] = preposicionexsalfabeto[15] + 1;
                                    break;
                                case 'p':
                                    preposicionexsalfabeto[16] = preposicionexsalfabeto[16] + 1;
                                    break;
                                case 'q':
                                    preposicionexsalfabeto[17] = preposicionexsalfabeto[17] + 1;
                                    break;
                                case 'r':
                                    preposicionexsalfabeto[18] = preposicionexsalfabeto[18] + 1;
                                    break;
                                case 's':
                                    preposicionexsalfabeto[19] = preposicionexsalfabeto[19] + 1;
                                    break;
                                case 't':
                                    preposicionexsalfabeto[20] = preposicionexsalfabeto[20] + 1;
                                    break;
                                case 'u':
                                    preposicionexsalfabeto[21] = preposicionexsalfabeto[21] + 1;
                                    break;
                                case 'v':
                                    preposicionexsalfabeto[22] = preposicionexsalfabeto[22] + 1;
                                    break;
                                case 'w':
                                    preposicionexsalfabeto[23] = preposicionexsalfabeto[23] + 1;
                                    break;
                                case 'x':
                                    preposicionexsalfabeto[24] = preposicionexsalfabeto[24] + 1;
                                    break;
                                case 'y':
                                    preposicionexsalfabeto[25] = preposicionexsalfabeto[25] + 1;
                                    break;
                                case 'z':
                                    preposicionexsalfabeto[26] = preposicionexsalfabeto[26] + 1;
                                    break;
                            }
                        }
                    }
                }
            }
            numeroadjetivos.Add(numadjetivos);
            numeropronombres.Add(numpronombres);
            numeroarticulos.Add(numarticulos);
            numeropreposiciones.Add(numpreposiciones);
            for(int i=0; i < 27; i++)
            {
                letraABC = new Letra { letra=abecedario[i], preposiciones=preposicionexsalfabeto[i], adjetivos=adjetivosxalfabeto[i], articulos=articulosxalfabeto[i], pronombres=pronombresxalfabeto[i] };
                listaLetra.Add(letraABC);
            }
            listaGlosarioCap.Add(glosarioCap = new GlosarioCapitulo
            {
                capitulo = "Capitulo " + numcap,
                Totalpreposiciones = numeropreposiciones[numcap - 1],
                Totalpronombres = numeropronombres[numcap - 1],
                Totalarticulos = numeroarticulos[numcap - 1],
                Totaladjetivos = numeroadjetivos[numcap - 1],
                Letra = listaLetra

            });

        }
        static void Main(string[] args)
        {
            int numcapitulo, totalpronombre=0, totaladjetivo=0, totalarticulo=0, totalpreposicion=0;
            List<Capitulo> pronombreCapitulo = new List<Capitulo>();
            List<Capitulo> adjetivoCapitulo = new List<Capitulo>();
            List<Capitulo> articuloCapitulo = new List<Capitulo>();
            List<Capitulo> preposicionCapitulo = new List<Capitulo>();
            List<Letra> letraAbecedario = new List<Letra>();
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
                Adjetivo=adjetivoCapitulo
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
            var jsonglosario = new Glosario
            {
                nombre = "Libro Don Quijote",
                numeroPalabras = numeropalabras,
                Capitulo = listaGlosarioCap
            };
            string json= JsonConvert.SerializeObject(jsonpronombres);
            string json2 = JsonConvert.SerializeObject(jsonadjetivos);
            string json3 = JsonConvert.SerializeObject(jsonarticulos);
            string json4 = JsonConvert.SerializeObject(jsonpreposiciones);
            string json5 = JsonConvert.SerializeObject(jsonglosario);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonpronombres.json", json);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonadjetivos.json", json2);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonarticulos.json", json3);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonpreposiciones.json", json4);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonglosario.json", json5);
            Console.WriteLine("Fin del programa");

            Console.ReadLine();
        }
    }
}
