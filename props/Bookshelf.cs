using Godot;

public partial class Bookshelf : Interactable 
{
	public override void _Ready()
	{
		base._Ready();

		_emittedSignal = SignalsManager.SignalName.InteractedWithBookshelf;
	}
}
