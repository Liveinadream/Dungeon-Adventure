using Godot;
using System;

public partial class UIContainer : Container
{
    [Export]public ContainerType ContainerType{get;set;}
    
    [Export] public Button ButtonNode{get;set;}
    [Export] public TextureRect TextureNode{get;set;}
    [Export] public Label LabelNode{get;set;}
}
