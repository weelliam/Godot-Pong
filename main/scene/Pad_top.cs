using Godot;
using System;

public class Pad_top : RigidBody2D
{
    // Constant for pads speed
    public const int PAD_SPEED = 150;

    Vector2 court_size;
        
    public override void _Ready()
    {
        court_size = GetViewport().GetSize();
    }

   public override void _Process(float delta)
   {
        Vector2 velocity = new Vector2();
        if(Input.IsActionPressed("top_move_right")){
            velocity.x += 1;
        }
        if(Input.IsActionPressed("top_move_left")){
            velocity.x -= 1;
        }
        if (velocity.Length() > 0) {
            velocity = velocity.Normalized() * PAD_SPEED;
        }

        Position += velocity * delta;
        Position = new Vector2(
            Mathf.Clamp(Position.x, 0, court_size.x),
            Mathf.Clamp(Position.y, 0, court_size.y)
        );
   }
}
