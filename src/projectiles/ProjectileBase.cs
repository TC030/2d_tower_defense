using Godot;
using System;

public abstract partial class ProjectileBase : Node2D
{
  [Export] public float Speed { get; protected set; } = 400f;

  protected EnemyBase Target = null;
  protected float Damage = 0f;

  public virtual void Init(EnemyBase _target, float _damage)
  {
    this.Target = _target;
    this.Damage = _damage;
  }

  public override void _PhysicsProcess(double delta)
  {
    base._PhysicsProcess(delta);
    if (Target == null || !IsInstanceValid(Target))
    {
      QueueFree();
      return;
    }
  }
}