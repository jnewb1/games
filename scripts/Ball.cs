using Godot;

public partial class Ball : RigidBody2D {
	[Export] private int number;
	[Export] private bool stripes;

	[Export] Sprite2D stripe;
	[Export] Sprite2D solid;
	[Export] RichTextLabel text;

	public void Init(int _number, Color _color, bool _stripes) {
		number = _number;
		stripes = _stripes;

		solid.Modulate = stripes ? new Color("white") : _color;
		stripe.Modulate = _color;
		text.Text = number.ToString();
	}

	public float GetWidth() {
		return 20f;
	}

}
