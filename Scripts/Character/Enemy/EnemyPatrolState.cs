using Godot;
using System;

// 敌人巡逻状态
public partial class EnemyPatrolState : EnemyState
{
    [Export]private Timer idleTimerNode;
    [Export(PropertyHint.Range,"0,20,0.1")] private int maxIdleTime = 4;

    private int pointIndex;

    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
        pointIndex = Mathf.Wrap(pointIndex + 1, 0, characterNode.PathNode.Curve.PointCount+1);
        destination = GetPointGlobalPosition(pointIndex);
        characterNode.AgentNode.TargetPosition = destination;
        characterNode.AgentNode.NavigationFinished += HandleNavigationFinished;
        idleTimerNode.Timeout += HandleTimeout;
        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        characterNode.AgentNode.NavigationFinished -= HandleNavigationFinished;
        idleTimerNode.Timeout -= HandleTimeout;
        characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }

  
    public override void _PhysicsProcess(double delta)
    {
        if(!idleTimerNode.IsStopped())
            return;
        Move();
    }

    private void HandleNavigationFinished()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDEL);
        RandomNumberGenerator rng = new();
        idleTimerNode.WaitTime = rng.RandiRange(1, maxIdleTime);
        idleTimerNode.Start();
    }

      private void HandleTimeout()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);

        pointIndex = Mathf.Wrap(pointIndex + 1, 0, characterNode.PathNode.Curve.PointCount);

        destination = GetPointGlobalPosition(pointIndex);
        characterNode.AgentNode.TargetPosition = destination;
    }

}
