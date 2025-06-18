using System;

namespace Game.Scripts.Lantern
{
    public class LanternPowerTimerServices : ILanternPowerTimerServices
    {
        private readonly ILanternPowerTimer m_LanternPowerTimer = new LanternPowerTweeTimer();
        private readonly Action m_CallbackOnTimerEnd;

        public float RemainingTime => m_LanternPowerTimer.GetRemainingTime();
        
        public LanternPowerTimerServices(Action callbackOnTimerEnd)
        {
            m_CallbackOnTimerEnd = callbackOnTimerEnd;
        }

        public void StartTimer(float allTime, float remainingTime)
        {
            m_LanternPowerTimer.StartTimer(remainingTime, m_CallbackOnTimerEnd);
        }
    }
}