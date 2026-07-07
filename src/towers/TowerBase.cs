using Godot;
using System;
using System.Collections.Generic;

public abstract partial class TowerBase : Node2D
{
  [Export] public float TargetRange { get; protected set; } = 200f;
  [Export] public float AttackSpeed { get; protected set; } = 1f;
  
  protected List<EnemyBase> TargetsInRange = new List<EnemyBase>();
  protected EnemyBase CurrentTarget = null;
  private float attackCooldown = 0f;

  public override void _Ready()
  {
    base._Ready();
    GD.Print($"{Name} is ready. Target range: {TargetRange}, Attack speed: {AttackSpeed}");
    Area2D detectionArea = GetNode<Area2D>("DetectionArea");
    detectionArea.AreaEntered += OnDetectionAreaAreaEntered;
    detectionArea.AreaExited += OnDetectionAreaAreaExited;
  }

  private void OnDetectionAreaAreaEntered(Node body)
  {
    if (body is EnemyBase enemy)
    {
      TargetsInRange.Add(enemy);
      GD.Print($"{enemy.Name} entered {Name}'s range.");
    }
  }

  private void OnDetectionAreaAreaExited(Node body)
  {
    if (body is EnemyBase enemy)
    {
      TargetsInRange.Remove(enemy);
      GD.Print($"{enemy.Name} exited {Name}'s range.");
      if (CurrentTarget == enemy)
      {
        CurrentTarget = null;
        GD.Print($"{Name} lost its current target.");
      }
    }
  }

  public override void _PhysicsProcess(double delta)
  {
    base._PhysicsProcess(delta);
    UpdateTarget();
    HandleAttack(delta);
  }

  protected virtual void UpdateTarget()
  {
    TargetsInRange.RemoveAll(enemy => !GodotObject.IsInstanceValid(enemy));
    if (TargetsInRange.Count > 0)
    {
      CurrentTarget = TargetsInRange[0];
    }
    else
    {
      CurrentTarget = null;
    }
  }

  private void HandleAttack(double delta)
  {
    if (CurrentTarget == null) return;
  
    attackCooldown -= (float)delta;
    if (attackCooldown <= 0f)
    {
      Attack();
      attackCooldown = 1f / AttackSpeed;
    }
  }

  protected abstract void Attack();
}