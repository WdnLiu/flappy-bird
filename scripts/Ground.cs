using Godot;

public partial class Ground : Node2D
{
    [Export]
    public float speed = -150;
    private Sprite2D ground1;
    private Sprite2D ground2;
    private float textureWidth;

    private Area2D hitGround1;
    private Area2D hitGround2;

    public override void _Ready()
    {
        ground1 = GetNode<Sprite2D>("Ground1/Sprite2D");
        ground2 = GetNode<Sprite2D>("Ground2/Sprite2D");

        hitGround1 = GetNode<Area2D>("Ground1");
        hitGround2 = GetNode<Area2D>("Ground2");

        hitGround1.BodyEntered += OnBodyEntered;
        hitGround2.BodyEntered += OnBodyEntered;

        ground2.GlobalPosition = new Vector2(
            ground1.GlobalPosition.X + ground1.Texture.GetWidth(),
            ground1.GlobalPosition.Y
        );

        textureWidth = ground1.Texture.GetWidth();
    }

    public override void _Process(double delta)
    {
        ground1.GlobalPosition += new Vector2(speed * (float)delta, 0);
        ground2.GlobalPosition += new Vector2(speed * (float)delta, 0);

        CheckBounds();
    }

    private void CheckBounds()
    {
        if (ground1.GlobalPosition.X < -textureWidth)
        {
            ground1.GlobalPosition = new Vector2(
                ground2.GlobalPosition.X + textureWidth,
                ground1.GlobalPosition.Y
            );
        }
        if (ground2.GlobalPosition.X < -textureWidth)
        {
            ground2.GlobalPosition = new Vector2(
                ground1.GlobalPosition.X + textureWidth,
                ground2.GlobalPosition.Y
            );
        }
    }

    public void OnBodyEntered(Node2D body)
    {
        if (body is Bird bird)
        {
            bird.OnHitFloor();
        }
    }
}
