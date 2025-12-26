using Godot;

public partial class FlappingState(Bird bird) : BirdState(bird)
{
    private const float rotationSpeedUp = 0.2f;
    private const float rotationSpeedDown = 0.05f;
    private static readonly float maxAngleUp = Mathf.DegToRad(-30f);
    private static readonly float maxAngleDown = Mathf.DegToRad(90f);

    public override void PhysicsProcess(double delta)
    {
        bird.Velocity += new Vector2(0, bird.Gravity * (float)delta);

        RotateBird();

        bird.MoveAndCollide(bird.Velocity * (float)delta);
    }

    public override void HandleInput(InputEvent @event)
    {
        if (@event.IsActionPressed("flap"))
        {
            bird.Jump();
            bird.AnimPlayer.Play("flap_wings");
        }
    }

    public override void HandleCollision()
    {
        bird.GetTree().CallDeferred(SceneTree.MethodName.ReloadCurrentScene);
    }

    private void RotateBird()
    {
        float targetAngle = Mathf.Clamp(bird.Velocity.Y * 0.003f, maxAngleUp, maxAngleDown);
        float weight = (bird.Velocity.Y < 0) ? rotationSpeedUp : rotationSpeedDown;

        bird.Rotation = Mathf.LerpAngle(bird.Rotation, targetAngle, weight);
    }
}
