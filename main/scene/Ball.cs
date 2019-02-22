using Godot;
using System;

public class Ball : RigidBody2D
{
    public Vector2 direction = new Vector2(0.80f, -1.0f);

    // Constant for ball speed (in pixels/second)
    public const int INITIAL_BALL_SPEED = 200;
    // Speed of the ball (also in pixels/second)
    public float ballSpeed = INITIAL_BALL_SPEED;
    Vector2 court_size;

    Random random;

    public override void _Ready()
    {
        court_size = GetViewport().GetSize();
        random = new Random();
    }

    public override void _Process(float delta)
    {
        Position = Position + (direction * ballSpeed * delta);

        // Flip when touching border or floor
        if ((Position.x < 0 && direction.x < 0) || (Position.x > court_size.x && direction.x > 0)){
            direction.x = -direction.x;
        }
    }

    public void OnBallBodyEntered(Godot.Object body){
        direction.y = -direction.y;
        direction.x = NextFloat(random);
        direction = direction.Normalized();
        ((Ball)GetNode("Ball")).ballSpeed *= 1.1f;
    }

    static float NextFloat(Random random)
    {
        double mantissa = (random.NextDouble() * 2.0) - 1.0;
        // choose -149 instead of -126 to also generate subnormal floats (*)
        double exponent = Math.Pow(2.0, random.Next(-126, 128));
        return (float)(mantissa * exponent);
    }
}
