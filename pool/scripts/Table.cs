using System;
using System.Collections.Generic;
using Godot;


public static class TriangleNumbers {

  /*
  1
  2 3
  4 5 6
  */

  public static int GetRow(int n) {
    return (int)Math.Ceiling((Math.Sqrt(8*n + 1) - 1) / 2);
  }

  public static int GetCol(int n) {
    return n - GetRow(n) * (GetRow(n) - 1) / 2;
  }

  public static Vector2 GetPosition(int n) {
    return new Vector2(GetRow(n), GetCol(n) - GetRow(n)/2f);
  }
}

public partial class Table : Node2D {
  private static (int, Color, bool)[] POOL_BALLS = new[] {
    (5, new Color("orange"), false),
    (11, new Color("red"), true),
    (3, new Color("red"), false),
    (2, new Color("dark blue"), false),
    (8, new Color("black"), false),
    (10, new Color("dark blue"), true),
    (9, new Color("yellow"), true),
    (7, new Color("maroon"), false),
    (14, new Color("dark green"), true),
    (4, new Color("purple"), false),
    (15, new Color("maroon"), true),
    (6, new Color("dark green"), false),
    (13, new Color("orange"), true),
    (12, new Color("purple"), true),
    (1, new Color("yellow"), false),
  };

  [Export] Node2D[] pockets;

  public Ball cue;
  
  [Export] PackedScene ball_template;

  Vector2 table_size = new Vector2(262, 150);

  float head_offset = 70;
  float foot_offset = 70;

  private Vector2 GetFootSpot() {
    return new Vector2(table_size.X - foot_offset, table_size.Y / 2);
  }

  private Vector2 GetHeadSpot() {
    return new Vector2(head_offset, table_size.Y / 2);
  }

  public Vector2 GetBallPosition(int n, float ball_size) {
    return TriangleNumbers.GetPosition(n + 1) * ball_size;
  }

  public override void _Ready()
  {
    cue = ball_template.Instantiate<Ball>();
    cue.Init(0, new Color(1,1,1), false);
    cue.Position = GetHeadSpot();
    AddChild(cue);

    for (int i = 0; i < POOL_BALLS.Length; i++) {
      Ball ball = ball_template.Instantiate<Ball>();
      ball.Init(POOL_BALLS[i].Item1, POOL_BALLS[i].Item2, POOL_BALLS[i].Item3);
      ball.Position = GetFootSpot() + GetBallPosition(i, 6.2f);
      AddChild(ball);
    }
  }
}
