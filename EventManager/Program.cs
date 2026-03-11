using System;
using GameEvent;
using GameSystem;

ScoreSystem s_score = new ScoreSystem();
AchievementSystem s_achieve = new AchievementSystem();
SoundSystem s_sound = new SoundSystem();

EventManager.OnGameEvent += s_score.ScoreChanged;
EventManager.OnGameEvent += s_achieve.Achievement;

EventManager.TriggerEvent("ScoreChanged", 100);
EventManager.TriggerEvent("Achievement", "첫 번째 적 처치");
EventManager.TriggerEvent("GameOver");