using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace FsModel
{
    public class Vejr
    {
        public string APIKEY { get { return "7428786f11b4f7ef623552137d89dd59"; } }
        public string location { get; set; } = "København";
        public string CurrentURL { get; set; } = "http://api.openweathermap.org/data/2.5/weather?q=København&mode=xml&units=metric&APPID=7428786f11b4f7ef623552137d89dd59";

        public string WindSpeed { get { return GetWindSpeed(); } }

        private XDocument Access()
        {
            using (WebClient client = new WebClient())
            {
                string xmlContent = client.DownloadString(CurrentURL);
                XDocument xDocument = XDocument.Parse(xmlContent);
                return xDocument;
            }
        }
        public string Temperature()
        {
            return Access().Descendants("temperature").First().Attribute("value").Value;
        }
        public string TemperatureMin()
        {
            return Access().Descendants("temperature").First().Attribute("min").Value;
        }
        public string TemperatureMax()
        {
            return Access().Descendants("temperature").First().Attribute("max").Value;
        }
        public string GetWindSpeed()
        {
            return Access().Descendants("speed").First().Attribute("value").Value;
        }
        public string WindSpeedName()
        {
            return Access().Descendants("speed").First().Attribute("name").Value;
        }
        public string WindDirection()
        {
            if (WindSpeed != "0")
                return Access().Descendants("direction").First().Attribute("value").Value;
            return "n/a";
        }
        public string WindDirectionName()
        {
            if (WindSpeed != "0")
                return Access().Descendants("direction").First().Attribute("name").Value;
            return "n/a";
        }
        public string Country()
        {
            return Access().Descendants("country").First().Value;
        }
        public string City()
        {
            return Access().Descendants("city").First().Attribute("name").Value;
        }
    }
}
