using System;
using System.Collections.Generic;
using System.Text;

namespace DontForgetToSubscribeLikeandComment
{
    class User : IUser
    {
        private string _name = "";

        public string GetName()
        {
            return _name;
        }

        public User(string name)
        {
            _name = name;
        }

        public void Notify(string channel, string video)
        {
            Console.WriteLine("Yo " + _name + "! " + channel + " uploaded video \"" + video + "\"");
        }
    }
}