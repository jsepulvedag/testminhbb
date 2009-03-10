using System;
using System.Xml;
using System.Collections;

namespace Restaurant.Presentation.Library
{
    public class PageEnvironment
    {
        private Hashtable _controls = new Hashtable();
        public Hashtable Controls
        {
            get { return _controls; }
        }
        public PageEnvironment(string configPath)
        {
            GetControlsList(configPath);
        }
        private void GetControlsList(string pathToConfigFile)
        {
            XmlTextReader reader = new XmlTextReader(pathToConfigFile);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "Page")
                        {
                            reader.MoveToNextAttribute();
                            string key = reader.Value.ToLower();
                            reader.MoveToNextAttribute();
                            string value = reader.Value;
                            _controls.Add(key, value);
                        }
                        break;
                }
            }
            reader.Close();
        }
    }
}
