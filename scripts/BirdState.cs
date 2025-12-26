using Godot;

public abstract partial class BirdState(Bird bird) : RefCounted
{
    protected Bird bird = bird;

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Process(double _delta) { }

    public virtual void PhysicsProcess(double _delta) { }

    public virtual void HandleInput(InputEvent @event) { }

    public virtual void HandleCollision() { }
}
