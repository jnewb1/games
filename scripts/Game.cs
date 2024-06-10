using System;
using Godot;

public partial class Game : Node2D {
  [Export]
  private Stick stick;

  [Export]
  private StickVisualization stickVisualization;

  [Export]
  private Table table;

  private int MAX_POWER = 50;

  private Vector2? start_shot = null;
  private Vector2 cur_shot;
  public override void _Ready()
  {
    
  }

  public float CurrentPower {
    get {
      return Math.Min(Math.Abs((start_shot.Value - cur_shot).Length()), MAX_POWER);
    }
  }

  public override void _UnhandledInput(InputEvent @event)
  {
    if (@event is InputEventMouseButton eventMouseButton) {
      if (eventMouseButton.ButtonIndex == MouseButton.Left) {
        if (eventMouseButton.Pressed) {
          start_shot = eventMouseButton.Position;
        }
        else{
          if (start_shot != null) {
            table.cue.LinearVelocity = (start_shot.Value - cur_shot) * 5;
          }
          start_shot = null;
        }
      }
    }

    if (@event is InputEventMouseMotion eventMouseMotion) {
      cur_shot = eventMouseMotion.Position;
    }
  }

  public override void _Process(double delta)
  {
    if (start_shot is null) {
      stick.Visible = false;
    }
    else {
      stick.VisualizeShot(table.cue.GlobalPosition, cur_shot, start_shot.Value);
      stickVisualization.SetPower(CurrentPower / MAX_POWER);
    }
  }
}
