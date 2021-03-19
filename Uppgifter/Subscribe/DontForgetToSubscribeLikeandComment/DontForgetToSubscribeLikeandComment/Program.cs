using System;
using System.Collections.Generic;

namespace DontForgetToSubscribeLikeandComment
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel coolYoutubeChannel = new Channel("coolYotubeChannel");

            User user1 = new User("User1");
            User user2 = new User("User2");
            User user3 = new User("User3");



            coolYoutubeChannel.Subscribe(user1);
            coolYoutubeChannel.Subscribe(user2);
            coolYoutubeChannel.Subscribe(user3);


            coolYoutubeChannel.AddVideo("Very Nice video bre!");

        


    }
}
}
