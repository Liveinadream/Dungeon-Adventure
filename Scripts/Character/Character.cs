using System;
using Godot;
using System.Linq;

public abstract partial class Character : CharacterBody3D{
    [Export] public StatResource[] Stats{get; set;}

    [ExportGroup("Required Nodes")] 
    [Export] public AnimationPlayer AnimationPlayerNode{get; private set;}
    [Export] public Sprite3D Sprite3DNode{get; private set;}
    [Export] public StateMachine StateMachineNode{get;  set;}
    [Export] public Area3D HurtboxNode{get; private set;}
    [Export] public Area3D HitboxNode{get; private set;}
    [Export] public CollisionShape3D HitboxShapeNode{get; set;}
    [Export] public Timer ShaderTimerNode{get;private set;}

    [ExportGroup("AI Nodes")]
    [Export]public Path3D PathNode{get; set;} // Target node for the characte
    [Export] public NavigationAgent3D AgentNode{get; set;} // Agent node for the character to move
    [Export] public Area3D ChaseAreaNode{get; set;} // Area node for the character to chase the player
    [Export] public Area3D AttackAreaNode{get; set;} // Area node for the character to attack the player
    public Vector2 direction = Vector2.Zero;
    public int speed = 10;
    private ShaderMaterial shader;

    public override void _Ready() {
        shader = (ShaderMaterial)Sprite3DNode.MaterialOverlay;

        HurtboxNode.AreaEntered += HandleHurtboxEntered;
        Sprite3DNode.TextureChanged += HandleTextureChange;
        ShaderTimerNode.Timeout += HandlerShaderTimerOut;
    }

    private void HandlerShaderTimerOut()
    {
        shader.SetShaderParameter(
            "active", false
        );
    }

    private void HandleTextureChange()
    {
        shader.SetShaderParameter(
            "tex", Sprite3DNode.Texture
        );
    }

    private void HandleHurtboxEntered(Area3D area)
    {
        if (area is not IHitbox hitbox)
        {
            return;
        }
        
        StatResource health = GetStatResource(Stat.Health);
        float damage = hitbox.GetDamage();
        health.StatValue -= damage;
        GD.Print(health.StatValue);
        shader.SetShaderParameter(
            "active", true
        );
        ShaderTimerNode.Start();
    }

    public StatResource GetStatResource(Stat stat)
    {
        return Stats.Where((element) => element.StatType == stat)
            .FirstOrDefault();
    }

    public void FilpSprite()
    {
        bool isNotMovingHorizontally = Velocity.X  == 0;
        if (isNotMovingHorizontally)
        {
            return;
        }

        bool isMoveingLeft = Velocity.X < 0;
        Sprite3DNode.FlipH = isMoveingLeft;
    }

    public void ToggleHitbox(bool flag)
    {
        HitboxShapeNode.Disabled = flag;
    }

}