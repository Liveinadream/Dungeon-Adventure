using System;

public class GameEvents
{
    public static event Action OnStartGame;
    public static event Action OnEndGame;
    public static event Action<int> onNewEnemyCount;
    public static event Action onVictory;

    public static event Action<RewardResource> onReward;

    public static void RaiseOnReward(RewardResource reward)
    {
        onReward?.Invoke(reward);
    }
    public static void RaiseOnStartGame()
    {
        OnStartGame?.Invoke();
    }

    public static void RaiseOnEndGame()
    {
        OnEndGame?.Invoke();
    }

    public static void RaiseOnNewEnemyCount(int count)
    {
        onNewEnemyCount?.Invoke(count);
    }

    public static void RaiseOnVictory()
    {
        onVictory?.Invoke();
    }

    // public static void RaiseOnPauseGame()
    // {
    //     onPauseGame?.Invoke();
    // }
    // public static void RaiseOnContinueGame()
    // {
    //     onContinueGame?.Invoke();
    // }
}