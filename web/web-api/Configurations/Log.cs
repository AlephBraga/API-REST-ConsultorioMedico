using System;
using System.IO;

namespace web_api.Configurations
{
    public class Log
    {
        public static string getFullPath()
        {
            string fileName = $"{DateTime.Now.ToString("dd-MM-yyyy")}.txt";
            string path = System.Configuration.ConfigurationManager.AppSettings["consultorio-caminho-log"];
            string fullpath = Path.Combine(path, fileName);
            return fullpath;
        }
    }
}