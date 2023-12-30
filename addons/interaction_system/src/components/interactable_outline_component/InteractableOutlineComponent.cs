using Godot;

namespace InteractionSystem.Components
{
	[Tool]
	public partial class InteractableOutlineComponent : Node
	{
		[Export] public bool Enabled { get; set; } = true;
		[Export] public Node Outline { get; set; }
		[Export] public Interactable.Interactable Prop { get; set; }

		[ExportGroup("Outline On")]
		[Export] public bool OutlineOnFocus { get; set; } = true;
		[Export] public bool OutlineOnClosest { get; set; } = true;

		private MeshInstance2D _outline2D;
		private MeshInstance3D _outline3D;

		public override void _Ready()
		{
			if (Engine.IsEditorHint()) return;

			Prop.Focused += OnFocus;
			Prop.Unfocused += OnFocusLost;
			Prop.Closest += OnClosest;
			Prop.NotClosest += OnNotClosest;

			InitializeOutline();

			HideOutline();
		}

		private void InitializeOutline()
		{
			if (Outline is MeshInstance2D) _outline2D = Outline as MeshInstance2D;
			else if (Outline is MeshInstance3D) _outline3D = Outline as MeshInstance3D;
		}

		private void ShowOutline()
		{
			_outline2D?.Show();
			_outline3D?.Show();
		}

		private void HideOutline()
		{
			_outline2D?.Hide();
			_outline3D?.Hide();
		}

		private void OnFocus(Interactor.Interactor interactor)
		{
			if (OutlineOnFocus) ShowOutline();
		}

		private void OnFocusLost(Interactor.Interactor interactor)
		{
			if (OutlineOnFocus) HideOutline();
		}

		private void OnClosest(Interactor.Interactor interactor)
		{
			if (OutlineOnClosest) ShowOutline();
		}

		private void OnNotClosest(Interactor.Interactor interactor)
		{
			if (OutlineOnClosest) HideOutline();
		}
	}
}
