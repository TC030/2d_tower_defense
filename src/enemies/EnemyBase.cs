using Godot;
using System;

public abstract partial class EnemyBase : Area2D
{
  [Export] public float Speed { get; protected set; } = 100f;
  [Export] public float MaxHealth { get; protected set; } = 100f;
  public float CurrentHealth { get; protected set; }

  public override void _Ready()
  {
    base._Ready();
    CurrentHealth = MaxHealth;
  }
  public virtual void TakeDamage(float amount)
  {
    CurrentHealth -= amount;
    GD.Print($"{Name} took {amount} damage. Current health: {CurrentHealth}/{MaxHealth}");
    if (CurrentHealth <= 0) Die();
  }



  protected virtual void Die()
  {
    GD.Print($"{Name} has died.");
    GetParent().QueueFree();
    QueueFree();
  }
}