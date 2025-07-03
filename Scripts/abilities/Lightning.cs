using Godot;
using System;

//连击后的闪电
public partial class Lightning : Ability
{
    public override void _Ready()
    {
        base._Ready();
        PlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        QueueFree();
    }
}
