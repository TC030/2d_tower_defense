using Godot;
using System;

public partial class NormalTower : TowerBase
{
	private float Damage = 10f;
	public override void _Ready()
	{
		base._Ready();
	}

	protected override void Attack()
	{
		if (CurrentTarget != null)
		{
			CurrentTarget.TakeDamage(Damage);
			GD.Print($"{Name} attacked {CurrentTarget.Name} for {Damage} damage.");
		}
		else
		{
			GD.Print($"{Name} has no enemy to attack.");
		}
	}
  public override void _PhysicsProcess(double delta)
  {
    base._PhysicsProcess(delta);
  }
}
