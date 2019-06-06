using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto;
            Console.Write("Ingrese algun texto:\n");
            texto = Console.ReadLine();
            using (StreamWriter sw = new StreamWriter("morse.txt") ) {
                texto = Helpers.ConversorDeMorse.TextoAMorse(texto);
                sw.WriteLine(texto);
                sw.Close();
            }

            using (StreamReader sr = new StreamReader("morse.txt")) {
                string morse;
                morse = sr.ReadLine();
                Console.WriteLine("texto convertido a morce: ");
                Console.WriteLine(morse);
                Console.Clear();
                morse = Helpers.ConversorDeMorse.MorseATexto(morse);
                Console.WriteLine("texto en morce convertido a texto:");
                Console.WriteLine(morse);
                StreamWriter swTxT = new StreamWriter("texto.txt");
                swTxT.WriteLine(morse);
                swTxT.Close();
            }

            string ruta;
            Helpers.SoporteParaConfiguracion.CrearArchivoDeConfiguracion();
            ruta=Helpers.SoporteParaConfiguracion.LeerConfiguracion();
            string[] direct_txt = Directory.GetFiles(".", "*.txt");
            string[] direct_mp3 = Directory.GetFiles(".", "*.mp3");
            Directory.CreateDirectory(ruta);
            foreach (var item in direct_txt)
            {
                if (Directory.Exists(ruta+item)) File.Move(item, ruta + item);
                else
                {
                    File.Delete(ruta + item);
                    File.Move(item, ruta + item);
                }
            }
            foreach (var item in direct_mp3)
            {
                if (Directory.Exists(ruta + item)) File.Copy(item, ruta + item);
                else
                {
                    File.Delete(ruta + item);
                    File.Copy(item, ruta + item);
                }
            }

            Helpers.ConversorDeMorse.MorseAudio(texto);


            Console.ReadKey();
        }
    }
}
