using Godot;
using System;

public partial class EnemyPathFollower : PathFollow2D
{
	private EnemyBase _enemy;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		_enemy = GetChild<EnemyBase>(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _PhysicsProcess(double delta)
  {
    base._PhysicsProcess(delta);
		if (_enemy == null) return;
    Progress += _enemy.Speed * (float)delta;
    if (ProgressRatio >= 1.0f)
    {
      GD.Print($"{_enemy.Name} has reached the end of the path.");
      QueueFree();
    }
  }
}
