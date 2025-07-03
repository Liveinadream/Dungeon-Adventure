using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

[GlobalClass]
public partial class UIController : Control
{
    private Dictionary<ContainerType, UIContainer> containers;

    private bool canPause = true;

    public override void _Ready()
    {
        containers = GetChildren().Where(element => element is UIContainer)
        .Cast<UIContainer>()
        .ToDictionary((element) => element.ContainerType);

        containers[ContainerType.Start].Visible = true;

        containers[ContainerType.Start].ButtonNode.Pressed +=HandleStartPressed;
        containers[ContainerType.Pause].ButtonNode.Pressed += HandleContinueGame;
        containers[ContainerType.Reward].ButtonNode.Pressed += HandleRewardPressed;

        GameEvents.OnEndGame += HandleEndGame;
        GameEvents.onVictory += HandleVictory;
        GameEvents.onReward  += HandleReward;
    }



    public override void _Input(InputEvent @event)
    {
        if (!canPause)
        {
            return;
        }

        if (!Input.IsActionJustPressed(GameConstants.INPUT_PAUSE))
        {
            return;
        }
        containers[ContainerType.Stats].Visible = GetTree().Paused;
        GetTree().Paused = !GetTree().Paused;
        containers[ContainerType.Pause].Visible = GetTree().Paused;
    }


    private void HandleContinueGame()
    {
        containers[ContainerType.Pause].Visible = false;
        GetTree().Paused = false;
    }

    private void HandlePauseGame()
    {
        containers[ContainerType.Pause].Visible = false;
        containers[ContainerType.Stats].Visible = true;
        GetTree().Paused = true;
    }

    private void HandleVictory()
    {
        canPause = false;
        containers[ContainerType.Start].Visible = false;
        containers[ContainerType.Victory].Visible = true;
        GetTree().Paused = true;
    }

    private void HandleEndGame()
    {
        canPause = false;
        containers[ContainerType.Start].Visible = false;
        containers[ContainerType.Defeat].Visible = true;
    }

    private void HandleStartPressed()
    {
        canPause = true;
        GetTree().Paused = false;
        containers[ContainerType.Start].Visible = false;
        containers[ContainerType.Stats].Visible = true;
        GameEvents.RaiseOnStartGame();
    }

    private void HandleReward(RewardResource resource)
    {
        canPause = false;
        GetTree().Paused = true;
        containers[ContainerType.Stats].Visible = false;
        containers[ContainerType.Reward].Visible = true;

        containers[ContainerType.Reward].TextureNode.Texture = resource.SpriteTexture;
        containers[ContainerType.Reward].LabelNode.Text = resource.Description;
    }

    private void HandleRewardPressed()
    {
        canPause = true;
        GetTree().Paused = true;
        containers[ContainerType.Stats].Visible = false;
        containers[ContainerType.Reward].Visible = true;
    }
}
