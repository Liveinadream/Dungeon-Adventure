using Godot;
using System;

//通过能力使敌人被打击的状态
public partial class EnemyStunState : EnemyState
{
    protected override void EnterState()
    {
        base.EnterState();
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_STUN);
        characterNode.AnimationPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        if(characterNode.AttackAreaNode.HasOverlappingBodies()){
            characterNode.StateMachineNode.SwitchState<EnemyAttackState>();
        }
        else if(characterNode.ChaseAreaNode.HasOverlappingBodies()){
            characterNode.StateMachineNode.SwitchState<EnemyChaseState>();
        }
        else{
            characterNode.StateMachineNode.SwitchState<EnemyIdleState>();
        }
    }

    protected override void ExitState()
    {
        base.ExitState();
        characterNode.AnimationPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }
}
