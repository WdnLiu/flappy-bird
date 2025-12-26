using Godot;

public partial class PipeSpawner : Node2D
{
    [Export]
    public PackedScene PipeEntityScene;

    [Export]
    public float spawnRate = 1.5f;
    private Timer spawnTimer;

    public override void _Ready()
    {
        spawnTimer = GetNode<Timer>("Timer");
        spawnTimer.WaitTime = spawnRate;
        spawnTimer.Timeout += OnSpawnerTimeout;
        spawnTimer.Start();
    }

    private void OnSpawnerTimeout()
    {
        SpawnPipe();
        GD.Print("Spawned");
    }

    private void SpawnPipe()
    {
        PipeEntity pipe = PipeEntityScene.Instantiate<PipeEntity>();

        AddChild(pipe);

        pipe.SetSpeed(-150);

        pipe.GlobalPosition = new Vector2(GlobalPosition.X + 200, (float)GD.RandRange(-150, 150));
    }
}
