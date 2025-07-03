using Godot;
using System;

public partial class PlayerAttackState : PlayerState
{
    [Export] private Timer comboTimerNode;
    [Export] private PackedScene lightningScene;
    private int comboCount  = 1;
    private int maxComboCount = 2;

    public override void _Ready()
    {
        base._Ready();
        comboTimerNode.Timeout += () => comboCount = 1;
    }

    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK + comboCount,-1,3f);
        characterNode.AnimationPlayerNode.AnimationFinished += HandleAnimationFinished;

        characterNode.HitboxNode.BodyEntered += HandleBodyEntered;
    }

    private void HandleBodyEntered(Node3D body)
    {
        if (comboCount != maxComboCount)
        {
            return;
        }

        Node3D lightning = lightningScene.Instantiate<Node3D>();
        GetTree().CurrentScene.AddChild(lightning);
        lightning.GlobalPosition = body.GlobalPosition;
    }

    protected override void ExitState()
    {
        characterNode.AnimationPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        comboCount++;
        comboCount = Mathf.Wrap(comboCount, 1, maxComboCount+1);
        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
        characterNode.ToggleHitbox(true);
    }

    private void PerformHit()
    {
        Vector3 newPosition = characterNode.Sprite3DNode.FlipH ? Vector3.Left: Vector3.Right;
        float distanceMultiplier = 0.75f;
        newPosition *= distanceMultiplier;

        characterNode.HitboxNode.Position = newPosition;
        characterNode.ToggleHitbox(false);
        GD.Print("Perform Hit!");
    }
}
