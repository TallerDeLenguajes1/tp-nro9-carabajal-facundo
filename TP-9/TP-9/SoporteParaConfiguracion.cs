using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class SoporteParaConfiguracion
    {
        public static void CrearArchivoDeConfiguracion() {
            string ruta = "config.dat";
            string[] directorios = Directory.GetLogicalDrives();
            BinaryWriter sw = new BinaryWriter(File.Open("config.dat",FileMode.Create));
            string Ruta = directorios[0]+"temporal";
            sw.Write(Ruta);
            sw.Close();
        }
        public static string LeerConfiguracion() {
            string ar;
            BinaryReader sr = new BinaryReader(File.Open("config.dat",FileMode.Open));
            ar = sr.ReadString();
            return ar;
        }
    }
}
