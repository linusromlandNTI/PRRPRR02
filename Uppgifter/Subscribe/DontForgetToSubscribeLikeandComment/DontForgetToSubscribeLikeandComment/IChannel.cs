using System;
using System.Collections.Generic;
using System.Text;

namespace DontForgetToSubscribeLikeandComment

{
    interface IChannel
    {
        void Subscribe(User user);

        void Unsubscribe(User user);

        void AddVideo(string vid);
    }
}