using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cliente.Logica
{
    public class Esquema
    {
        string sPath;
        List<Opcion> lst;

        public Esquema(string path)
        {
            lst = new List<Opcion>();
            sPath = path;
        }

        public List<Opcion> getEsquema()
        {
            if (lst.Count == 0)
                leerEsquema();

            return lst;
        }

        private void leerEsquema()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(sPath + @"\Esquema\Esquema.xml");

            lst = Util.ToNonNullList(Util.GetEntities<Opcion>(ds.Tables[0]));
         
        }




      

    }
}
