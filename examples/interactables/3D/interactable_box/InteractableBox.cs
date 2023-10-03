using Godot;

public partial class InteractableBox : Node3D
{
	private Label3D _label;
	private Interactable3D _interactable;

	public override void _Ready()
	{
		_label = GetNode<Label3D>("Label3D");
		_interactable = GetNode<Interactable3D>("Interactable3D");
		_interactable.Interacted += OnInteract;
		_interactable.Closest += OnClosest;
		_interactable.NotClosest += OnNotClosest;
		_interactable.Focused += OnFocused;
		_interactable.Unfocused += OnUnfocused;
	}

	private void OnInteract(Interactor3D interactor)
	{
		_label.Text = "Interacted with the box!";
	}

	private void OnClosest(Interactor3D interactor)
	{
		_label.Text = "Closest to the box!";
	}

	private void OnNotClosest(Interactor3D interactor)
	{
		_label.Text = "Not closest to the box!";
	}

	private void OnFocused(Interactor3D interactor)
	{
		_label.Text = "Focused on the box!";
	}

	private void OnUnfocused(Interactor3D interactor)
	{
		_label.Text = "Unfocused from the box!";
	}
}
