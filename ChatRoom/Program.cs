using System;

ChatRoom room = new();
ChatLogger logger = new(room);
NotificationService notification = new(room);

room.SendMessage("철수", "안녕하세요");
room.SendMessage("영희", "뭔가 긴급하네요");
room.SendMessage("민수", "점심 뭐 먹을까요?");