using Godot;
using System;

public partial class EnemyCountLabel : Label
{
    public override void _Ready()
    {
        GameEvents.onNewEnemyCount += OnNewEnemyCount;
    }

    private void OnNewEnemyCount(int count)
    {
        Text = $"{count}";
    }
}
