using Scada.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Scada.Server.Modules.ModAbc.Logic
{
    public static class RepositoryAppObject
    {
        public static List<AppObject> AppObjectsList { get; set; }

        static RepositoryAppObject()
        {
            AppObjectsList = new List<AppObject>();
            GetAllAppObjects();
        }

        private static void GetAllAppObjects()
        {
            string path = @"C:\Program Files\SCADA\ScadaServer\Mod\ModAbcLogicConfig.xml";

            if (File.Exists(path))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);
                XmlElement? root = xDoc.DocumentElement;

                if (root != null)
                {
                    foreach (XmlElement xElem in root)
                    {
                        AppObjectsList.Add(new AppObject(
                            int.Parse(xElem.ChildNodes[0].InnerText),
                            xElem.ChildNodes[1].InnerText,
                            xElem.ChildNodes[2].InnerText));
                    }                    
                }
            } 
        }
    }
}
