using Godot;

public partial class InteractableBox : Node3D
{
	private Interactable3D _interactable;

	public override void _Ready()
	{
		_interactable = GetNode<Interactable3D>("Interactable3D");
		_interactable.Interacted += OnInteract;
		_interactable.Closest += OnClosest;
		_interactable.NotClosest += OnNotClosest;
		_interactable.Focused += OnFocused;
		_interactable.Unfocused += OnUnfocused;
	}

	private void OnInteract(Interactor3D interactor)
	{
		GD.Print("Interacted with the box!");
	}

	private void OnClosest(Interactor3D interactor)
	{
		GD.Print("Closest to the box!");
	}

	private void OnNotClosest(Interactor3D interactor)
	{
		GD.Print("Not closest to the box!");
	}

	private void OnFocused(Interactor3D interactor)
	{
		GD.Print("Focused on the box!");
	}

	private void OnUnfocused(Interactor3D interactor)
	{
		GD.Print("Unfocused from the box!");
	}
}
