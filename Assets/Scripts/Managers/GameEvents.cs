using System;

public static class GameEvents
{
    public static Action<int> OnCoinsChanged;

    public static Action<int> OnLivesChanged;

    public static Action OnPlayerDeath;

    public static Action OnGameOver;

    public static Action OnItemCollected;
}