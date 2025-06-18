using System;
using DG.Tweening;

namespace Game.Scripts.Lantern
{
    public class LanternPowerTweeTimer : ILanternPowerTimer
    {
        private Tween m_CurrentTween;

        public void StartTimer(float delayInSeconds, Action callback)
        {
            m_CurrentTween?.Kill();
            m_CurrentTween = DOVirtual.DelayedCall(delayInSeconds, () =>
            {
                callback?.Invoke();
            });
        }

        public void StopTimer()
        {
            m_CurrentTween?.Kill();
            m_CurrentTween = null;
        }
        
        public float GetRemainingTime()
        {
            if (m_CurrentTween == null || !m_CurrentTween.IsActive())
                return 0f;

            return m_CurrentTween.Duration() - m_CurrentTween.Elapsed();
        }
    }
}