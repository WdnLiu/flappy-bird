using System.Runtime.CompilerServices;
using Godot;

public partial class PipeEntity : Node2D
{
    private float speed = -150;

    public override void _Ready()
    {
        Area2D topPipe = GetNode<Area2D>("TopPipe");
        Area2D bottomPipe = GetNode<Area2D>("BottomPipe");
        Area2D scoreZone = GetNode<Area2D>("ScoreZone");

        topPipe.BodyEntered += OnPipeHit;
        bottomPipe.BodyEntered += OnPipeHit;
        scoreZone.BodyEntered += OnPointScored;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public override void _Process(double delta)
    {
        Position += new Vector2(speed * (float)delta, 0);
    }

    private void OnPipeHit(Node2D body)
    {
        if (body is Bird bird)
        {
            bird.OnHitFloor();
        }
    }

    private void OnPointScored(Node2D body)
    {
        if (body is Bird bird)
        {
            bird.AddScore();
        }
    }
}
