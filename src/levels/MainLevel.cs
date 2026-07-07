using Godot;
using System;

public partial class MainLevel : Node
{
	[Export] public PackedScene EnemyScene;

	private Path2D _enemyPath;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		_enemyPath = GetNode<Path2D>("EnemyPath");
		SpawnTestEnemy();
	}

	private void SpawnTestEnemy()
	{
		if (EnemyScene == null)
		{
			GD.PrintErr("EnemyScene is not assigned.");
			return;
		}

		var enemyInstance = EnemyScene.Instantiate<EnemyBase>();
		if (enemyInstance == null)
		{
			GD.PrintErr("Failed to instantiate EnemyBase from EnemyScene.");
			return;
		}

		_enemyPath.AddChild(enemyInstance);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
