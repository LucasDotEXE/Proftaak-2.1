using System;
using Client;

namespace RHCClient
{
    class RHCClient : SocketClient
    {     
        public void sendClientMessage(string MessageType)
        {
            switch (MessageType)
            {
                case Config.loginPreset:
                    bool wronganswer = true;
                    bool newuser = true;
                    Console.WriteLine("Enter your username: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    string password = Console.ReadLine();
                    while (wronganswer) {
                    Console.WriteLine("Are you new to this application? y/n");
                    string answer = Console.ReadLine();
                        if (answer.Equals("y"))
                        {
                            newuser = true;
                            wronganswer = false;
                        }
                        if (answer.Equals("n"))
                        {
                            newuser = false;
                            wronganswer = false;
                        }
                        else
                        {
                            Console.WriteLine("Please enter y/n");
                        }
                    
                    }
                    string loginMessage = String.Format("{0}:{1}:{2}",username, password, newuser);
                    sendMessage(Config.loginPreset + loginMessage);
                    break;
                case Config.messagePreset:
                    string mMessage = Console.ReadLine();
                    sendMessage(Config.messagePreset + mMessage);
                    break;
            }
        }
    }
}
