using System.ComponentModel;
using Godot;

public partial class Bird : CharacterBody2D
{
    [Export]
    public AnimationPlayer AnimPlayer;

    [Export]
    public float Gravity = 900f;

    [Export]
    public float JumpForce = -400f;

    [Export]
    public BirdState nextState = null;

    private BirdState currState;

    public override void _Ready()
    {
        AnimPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        nextState = new IdleState(this);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (nextState != null)
            ChangeState();
        currState?.PhysicsProcess(delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        currState?.HandleInput(@event);
    }

    public void ChangeState()
    {
        currState?.Exit();
        currState = nextState;
        currState.Enter();
        nextState = null;
    }

    public void Jump()
    {
        Velocity = new Vector2(0, JumpForce);
    }

    public void OnHitFloor()
    {
        currState?.HandleCollision();
    }

    public void AddScore()
    {
        GD.Print("adding point");
    }
}
