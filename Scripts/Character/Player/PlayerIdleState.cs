using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
     public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        if(characterNode.direction != Vector2.Zero)
        {
            characterNode.StateMachineNode.SwitchState<PlayerMoveState>();
        }
    }
  
    public override void _Input(InputEvent @event)
    {
        CheckForAttack();
        if (@event.IsActionPressed(GameConstants.INPUT_DASH))
        {
            GD.Print("Input dash");
            characterNode.StateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDEL);
    }
}
