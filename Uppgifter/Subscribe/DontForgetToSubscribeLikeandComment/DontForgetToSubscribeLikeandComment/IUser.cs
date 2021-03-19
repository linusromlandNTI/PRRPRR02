using System;
using System.Collections.Generic;
using System.Text;

namespace DontForgetToSubscribeLikeandComment
{
    interface IUser
    {
        void Notify(string channel, string content);
    }
}