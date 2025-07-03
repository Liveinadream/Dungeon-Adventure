using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{

    protected override void EnterState()
    {
        base.EnterState();
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDEL);
        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        GD.Print("EnemyIdleState to EnemyReturnState");
        if(characterNode is null || characterNode.StateMachineNode is null)
        {
            GD.Print("EnemyIdleState to EnemyReturnState: characterNode or characterNode.StateMachineNode is null");
            return;
        }
        characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }
}
