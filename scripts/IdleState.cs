using Godot;

public partial class IdleState(Bird bird) : BirdState(bird)
{
    public override void Enter()
    {
        bird.AnimPlayer.Play("idle");
    }

    public override void HandleInput(InputEvent @event)
    {
        if (@event.IsActionPressed("flap"))
        {
            bird.nextState = new FlappingState(bird);
            bird.AnimPlayer.Stop();
        }
    }
}
