namespace Game.Scripts.Lantern
{
    public interface ILanternPowerTimerServices
    {
        void StartTimer(float allTime, float remainingTime);
        float RemainingTime { get; }
    }
}