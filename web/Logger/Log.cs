﻿using System;
using System.IO;

namespace Logger
{
    public class Log
    {
        public static void Write(Exception ex, string Path)
        { 
            using (StreamWriter sw = new StreamWriter(Path, true))
            {
               sw.WriteLine($"\n------\nData:{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} \n Mensagem:{ex.Message} \n StackTrace:{ex.StackTrace} \n InnerException:{ex.InnerException} \n Tipo do erro: {ex.GetType()} \n Source: {ex.Source} \n TargetSite: {ex.TargetSite}");
            }
        }
    }
}
