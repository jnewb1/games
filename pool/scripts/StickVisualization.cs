using Godot;

public partial class StickVisualization : Node2D {
  [Export]
  private float power;

  [Export]
  private Stick stick;

  public override void _Process(double delta)
  {
    stick.Position = new Vector2(stick.Position.X, power * 150);
  }

  public void SetPower(float _power) {
    power = _power;
  }
}