using Godot;
using System;

public class Main : Node
{
    Vector2 ScreenSize;

    Vector2 padSize;


    public override void _Ready()
    {
        ScreenSize = GetViewport().GetSize();
        padSize = ((Sprite)(GetNode("Pad").GetNode("Sprite"))).GetTexture().GetSize();
        this.SetProcess(true);
    }

    public override void _Process(float delta)
    {
        Ball ballNode = (Ball)GetNode("Ball");
        Vector2 ballPos = ((Node2D)GetNode("Ball")).Position;
        Rect2 topPad = new Rect2( ((Node2D)GetNode("Pad")).Position - padSize*0.5f, padSize );
        Rect2 bottomPad = new Rect2( ((Node2D)GetNode("Pad2")).Position - padSize*0.5f, padSize );

        Vector2 ballDirection = ((Ball)GetNode("Ball")).direction;

        
    }
}
