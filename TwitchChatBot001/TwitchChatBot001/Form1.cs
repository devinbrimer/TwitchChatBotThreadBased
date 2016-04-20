using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace TwitchChatBot001
{
    public partial class Form1 : Form
    {

        Queue<string> sendMessageQueue;
        TcpClient tcpClient;
        StreamReader reader;
        StreamWriter writer;
        string userName;
        string passWord;
        string channelName;
        string chatMessagePrefix;
        string chatCommandId;
        DateTime lastMessageTime;
        bool isBack;

        public Form1()
        {
            sendMessageQueue = new Queue<string>();
            userName = "brimerbot";
            passWord = File.ReadAllText("password.txt");
            channelName = "devin_brimer";
            chatCommandId = "PRIVMSG";
            chatMessagePrefix = $":{userName}!{userName}@{userName}.tmi.twitch.tv {chatCommandId} #{channelName} :";
            isBack = false;

            InitializeComponent();
            Reconnect();
        }

        void Reconnect()
        {
            isBack = false;
            tcpClient = new TcpClient("irc.twitch.tv", 6667);
            reader = new StreamReader(tcpClient.GetStream());
            writer = new StreamWriter(tcpClient.GetStream());
            writer.AutoFlush = true;

            writer.WriteLine("PASS " + passWord + Environment.NewLine
                + "NICK " + userName + Environment.NewLine
                + "USER " + userName + " 8 * :" + userName);
            writer.WriteLine("CAP REQ :twitch.tv/membership");
            writer.WriteLine("JOIN #" + channelName);
            lastMessageTime = DateTime.Now;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (!tcpClient.Connected)
            {
                Reconnect();
            }

            TryReceiveMessages();
            TrySendingMessages();
        }

        void TrySendingMessages()
        {
            string timeStamp = DateTime.Now.ToString("HH:mm");

            // send a message to chat stating the bots entry/return
            if (!isBack)
            {
                string returnMsg = $"Annnnnnd, I'm back...";
                writer.WriteLine($"{chatMessagePrefix}{returnMsg}");
                rtbRoom.AppendText($"\r\n<{timeStamp}> {userName} : {returnMsg}");
                rtbRoom.ScrollToCaret();
                isBack = true;
            }            

            // check the messages queue. if any, send them
            if (DateTime.Now - lastMessageTime > TimeSpan.FromSeconds(5))
            {
                if (sendMessageQueue.Count > 0)
                {
                    string outMessage = sendMessageQueue.Dequeue();

                    writer.WriteLine($"{chatMessagePrefix}{outMessage}");
                    
                    rtbRoom.AppendText($"\r\n<{timeStamp}> {userName} : {outMessage}");
                    rtbRoom.ScrollToCaret();

                    lastMessageTime = DateTime.Now;
                }
            }
            
        }

        void TryReceiveMessages()
        {
            if (tcpClient.Available > 0 || reader.Peek() >= 0)
            {
                string timeStamp = DateTime.Now.ToString("HH:mm:ss");
                string message = reader.ReadLine();

                // Pure messages received from server to Server rtb
                rtbServer.AppendText($"\r\n<{timeStamp}>{message}");
                rtbServer.ScrollToCaret();

                // if PING, then PONG
                if (message.Equals("PING :tmi.twitch.tv"))
                {
                    writer.WriteLine("PONG :tmi.twitch.tv");
                    rtbServer.AppendText($"\r\n<{timeStamp}>PONG :tmi.twitch.tv");
                    rtbServer.ScrollToCaret();
                }
                else // check if this is a standard chat message
                {
                    int iCollon = message.IndexOf(":", 1);
                    if (iCollon > 0)
                    {
                        string botCommand = message.Substring(1, iCollon);

                        if (botCommand.Contains(chatCommandId))
                        {
                            int iBang = botCommand.IndexOf("!");
                            if (iBang > 0)
                            {
                                string speaker = botCommand.Substring(0, iBang);
                                string chatMessage = message.Substring(iCollon + 1);
                                ReceiveMessage(speaker, chatMessage);
                            }
                        }
                    }
                }
            }
        }

        void ReceiveMessage(string speaker, string inMessage)
        {
            string timeStamp = DateTime.Now.ToString("HH:mm");
            
            rtbRoom.AppendText($"\r\n<{timeStamp}> {speaker} : {inMessage}");

            if (inMessage.Equals("!hi"))
            {
                SendMessage($"Hello, {speaker}");
            }
        }

        void SendMessage(string outMessage)
        {
            sendMessageQueue.Enqueue(outMessage);
        }
    }
}
