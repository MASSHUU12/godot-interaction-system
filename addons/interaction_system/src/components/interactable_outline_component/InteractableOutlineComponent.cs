using Godot;

namespace InteractionSystem.Components
{
	[Tool]
	public partial class InteractableOutlineComponent : Node
	{
		[Export] public bool Enabled { get; set; } = true;
		[Export] public MeshInstance3D Outline { get; set; }
		[Export] public Interactable.Interactable Prop { get; set; }

		[ExportGroup("Outline On")]
		[Export] public bool OutlineOnFocus { get; set; } = true;
		[Export] public bool OutlineOnClosest { get; set; } = true;

		public override void _Ready()
		{
			if (Engine.IsEditorHint()) return;

			Prop.Focused += OnFocus;
			Prop.Unfocused += OnFocusLost;
			Prop.Closest += OnClosest;
			Prop.NotClosest += OnNotClosest;

			Outline.Hide();
		}

		private void OnFocus(Interactor.Interactor interactor)
		{
			if (OutlineOnFocus) Outline.Show();
		}

		private void OnFocusLost(Interactor.Interactor interactor)
		{
			if (OutlineOnFocus) Outline.Hide();
		}

		private void OnClosest(Interactor.Interactor interactor)
		{
			if (OutlineOnClosest) Outline.Show();
		}

		private void OnNotClosest(Interactor.Interactor interactor)
		{
			if (OutlineOnClosest) Outline.Hide();
		}
	}
}
