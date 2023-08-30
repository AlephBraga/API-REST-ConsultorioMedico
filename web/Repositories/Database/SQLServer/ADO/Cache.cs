using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Database.SQLServer.ADO
{
    public class Cache
    {
        private static List<Models.Medico> cache = null;
        public static List<Models.Medico> getCache()
        {
            return cache;
        }
        public static void setCache(List<Models.Medico> medicos) { 
            cache = medicos;
        }
    }
}
