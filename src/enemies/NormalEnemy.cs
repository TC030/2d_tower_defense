using Godot;
using System;

public partial class NormalEnemy : EnemyBase
{
  public override void _Ready()
  {
    base._Ready();
    GD.Print($"{Name} is ready with {CurrentHealth}/{MaxHealth} health.");
  }
}