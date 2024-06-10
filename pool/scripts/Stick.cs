using System;
using Godot;


public partial class Stick : Node2D {
  [Export]
  private Node2D stick;

  internal void VisualizeShot(Vector2 cue_position, Vector2 cur_shot, Vector2 start_shot)
  {
    stick.Visible = true;
    stick.GlobalPosition = cue_position + 10f * (cur_shot - start_shot).Normalized();
    stick.LookAt(cue_position);
  }
}