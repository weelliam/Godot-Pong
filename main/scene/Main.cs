using Godot;
using System;

public class Main : Node
{
    var padSize
    var direction = new Vector2(1.0, 0.0)
       
    public override void _Ready()
    {
        _screenSize = GetViewport().GetSize();
        padSize = GetNode("Pad").GetTexture().GetSize();
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
