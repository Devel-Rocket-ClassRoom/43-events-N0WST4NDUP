using System;

namespace GameEvent
{
    public static class EventManager
    {
        public static EventHandler<GameEventArgs> OnGameEvent;

        public static void TriggerEvent(string eventName, object data = null)
        {
            OnGameEvent?.Invoke(eventName, new GameEventArgs(eventName, data));
        }
    }

    public class GameEventArgs : EventArgs
    {
        public readonly string EventName;
        public readonly object Data;

        public GameEventArgs(string eventName, object data)
        {
            EventName = eventName;
            Data = data;
        }
    }
}