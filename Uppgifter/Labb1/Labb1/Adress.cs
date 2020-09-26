using System;
using System.IO;
using System.Net;
using System.Xml;

namespace Labb1
{
    public class Adress
    { 

        public string _street;
        public int _streetNumber;
        public string _postAdress;
        public int _zipCode;

        public Adress()
        {
            Console.WriteLine("What is your street name?");
            _street = Console.ReadLine();
            while (true)
            {
                try
                {
                    Console.WriteLine("What is your street number?");
                    _streetNumber = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("not a number, try again!");
                }
                
            }
            _zipCode = getZipCode();
            _postAdress = getPostAdress(_zipCode);
            Console.WriteLine("\nYour Adress: \n" + _street + " " + _streetNumber + "\n" + _zipCode + " " + _postAdress);
        }
        public int getZipCode()
        {
            int zipcode;
            while (true)
            {
                try
                {
                    Console.WriteLine("Whats your Zipcode?");
                    zipcode = int.Parse(Console.ReadLine());
                    if(zipcode > 9999)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid Zipcode, try again!");
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Not a valid Zipcode, try again!");
                    continue;
                }
            }
            return zipcode;
        }

        static string getPostAdress(int zip)
        {
            XmlDocument xmlKey = new XmlDocument();
            xmlKey.Load("auth.xml");
            XmlNodeList xmlKeyNodeList = xmlKey.SelectNodes("keys");
            XmlNode xmlKeyNode = xmlKeyNodeList[0];
            string key = xmlKeyNode.SelectSingleNode("key").InnerText;
            string url = "https://api.papapi.se/lite/?query=" + zip + "&format=xml&apikey=" + key;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);
            responseReader.Close();
            XmlNodeList nodelist = doc.SelectNodes("results");
            XmlNode node = nodelist[0];
            return node.SelectSingleNode("result").SelectSingleNode("city").InnerText;
        }
    }
}
