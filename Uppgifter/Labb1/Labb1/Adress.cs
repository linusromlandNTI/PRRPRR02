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
                    _streetNumber = Program.intInput();
                    break;
                }
                catch
                {
                    Console.WriteLine("not a number, try again!");
                }
                
            }
            _zipCode = getZipCode();
            _postAdress = getPostAdress(_zipCode);
        }

        public int getZipCode()
        {
            int zipcode;
            while (true)
            {
                try
                {
                    Console.WriteLine("Whats your Zip Code?");
                    zipcode = Program.intInput();
                    if (zipcode > 9999)
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
            var response = "";
            try
            {
                string url = "http://zipcode.romland.space/?zip=" + zip;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                var webResponse = request.GetResponse();
                var webStream = webResponse.GetResponseStream();
                var responseReader = new StreamReader(webStream);
                response = responseReader.ReadToEnd();
            }
            catch
            {
                Console.WriteLine("Server not working currently! Type your Post Adress manually!");
                response = Console.ReadLine();
            }
            
            return response;
        }
    }
}
