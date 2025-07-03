using Godot;
using System;

/**
* 所有敌人节点管理
*/
public partial class EnemiesContainer : Node3D
{

    public override void _Ready()
    {
        int totalEnemies = GetChildCount();

        GameEvents.RaiseOnNewEnemyCount(totalEnemies);

        ChildExitingTree += HandleChildEnteredTree;
    }

    private void HandleChildEnteredTree(Node node)
    {
        int totalEnemies = GetChildCount() -1;

        GameEvents.RaiseOnNewEnemyCount(totalEnemies);

        if(totalEnemies == 0)
        {
            GameEvents.RaiseOnVictory();
        }
    }
}
