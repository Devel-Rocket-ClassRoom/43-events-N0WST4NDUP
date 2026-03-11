using System;
using GameEvent;

namespace GameSystem
{
    public class ScoreSystem
    {
        public void ScoreChanged(object sender, GameEventArgs e)
        {
            if (e.EventName == "ScoreChanged")
            {
                Console.WriteLine($"점수 변경: {e.Data}점");
            }
        }
    }

    public class AchievementSystem
    {
        public void Achievement(object sender, GameEventArgs e)
        {
            if (e.EventName == "Achievement")
            {
                Console.WriteLine($"업적 달성: {e.Data}");
            }
        }
    }

    public class SoundSystem
    {
        public SoundSystem()
        {
            EventManager.OnGameEvent += (sender, _) =>
            {
                Console.WriteLine($"[Sound] 이벤트: {sender}");
            };
        }
    }
}