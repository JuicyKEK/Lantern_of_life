using System;

namespace Game.Scripts.Lantern
{
    public interface ILanternPowerTimer
    {
        void StartTimer(float delayInSeconds, Action callback);
        void StopTimer();
        float GetRemainingTime();
    }
}