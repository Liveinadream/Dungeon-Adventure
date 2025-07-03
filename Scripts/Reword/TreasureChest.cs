using Godot;
using System;

public partial class TreasureChest : StaticBody3D
{
    [Export] private Area3D areaNode;
    [Export] private Sprite3D spriteNode;
    
    [Export] private RewardResource reward;

    bool canOpen = false;

    public override void _Ready()
    {
        areaNode.BodyEntered += HandleAreaBodyEntered;
        areaNode.BodyExited += HandleAreaBodyExited;
    }

    public override void _Input(InputEvent @event)
    {
        if (
            !areaNode.Monitoring || 
            !areaNode.HasOverlappingBodies() ||
            !Input.IsActionJustPressed(GameConstants.INPUT_INTERACT) )
        {
            return;
        }
        areaNode.Monitoring = false;
        GD.Print("Open Chest");
        GameEvents.RaiseOnReward(reward);
    }

    private void HandleAreaBodyExited(Node3D body)
    {
        spriteNode.Visible = false;
        canOpen = false;
    }

    private void HandleAreaBodyEntered(Node3D body)
    {
        spriteNode.Visible = true;
        canOpen = true;
    }
}
