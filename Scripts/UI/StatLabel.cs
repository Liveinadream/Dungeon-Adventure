using Godot;
using System;

public partial class StatLabel : Label
{

    [Export] private StatResource statResource;
    public override void _Ready()
    {
        base._Ready();
        statResource.OnUpdate += HandlerUpdate;
        Text = statResource.StatValue.ToString();
    }
    private void HandlerUpdate()
    {
        Text = statResource.StatValue.ToString();
    }
}
