using System;

public class NotificationService
{
    public NotificationService(ChatRoom chatroom)
    {
        chatroom.MessageReceived += Send;
    }
    public void Send(string _, string msg)
    {
        if (msg.Contains("긴급")) Console.WriteLine($"[알림] 긴급 메시지 수신!");
    }
}