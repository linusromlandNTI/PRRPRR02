using System;
using System.Collections.Generic;
using System.Text;

namespace DontForgetToSubscribeLikeandComment
{
    class Channel : IChannel
    {
        private string _name = "";
        public string GetName()
        {
            return _name;
        }

        public Channel(string name)
        {
            _name = name;
        }

        private List<User> subsribers = new List<User>();
        public void Subscribe(User user)
        {
            subsribers.Add(user);
        }

        public void SubscribeAll(User[] users)
        {
            foreach (var user in users)
            {
                subsribers.Add(user);
            }
            
        }

        public void Unsubscribe(User user)
        {
            subsribers.Remove(user);
        }

        public List<string> videos = new List<string>();
        public void AddVideo(string vid)
        {
            videos.Add(vid);

            foreach (var user in subsribers)
            {
                user.Notify(_name, vid);
            }
        }

    }
}