using Godot;
using System;

public abstract partial class PlayerState : CharacterState
{
    public override void _Ready()
    {
        base._Ready();
        characterNode.GetStatResource(Stat.Health).OnZero += HandlerZeroHealth;
    }

    private void HandlerZeroHealth()
    {
        characterNode.StateMachineNode.SwitchState<PlayerDeathState>();
    }

    protected void CheckForAttack()
    {
        if(Input.IsActionJustPressed(GameConstants.INPUT_ATTACK))
        {
            characterNode.StateMachineNode.SwitchState<PlayerAttackState>();
        }
    }
}