using System;

public class ChatLogger
{
    public ChatLogger(ChatRoom chatroom)
    {
        chatroom.MessageReceived += Send;
    }
    public void Send(string sender, string msg) => Console.WriteLine($"[로그] {sender}: {msg}");
}