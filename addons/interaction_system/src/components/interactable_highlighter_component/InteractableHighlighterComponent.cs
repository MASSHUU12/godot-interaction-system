using Godot;

namespace InteractionSystem.Components
{
	[Tool]
	public partial class InteractableHighlighterComponent : Node
	{
		[Export] public bool Enabled { get; set; } = true;

		[Export]
		public Interactable.Interactable Prop
		{
			get => _prop;
			set
			{
				if (value != _prop)
				{
					_prop = value;
					UpdateConfigurationWarnings();
				}
			}
		}
		[Export]
		public MeshInstance3D Mesh
		{
			get => _mesh;
			set
			{
				if (value != _mesh)
				{
					_mesh = value;
					UpdateConfigurationWarnings();
				}
			}
		}
		[Export]
		public ShaderMaterial Shader
		{
			get => _shader;
			set
			{
				if (value != _shader)
				{
					_shader = value;
					UpdateConfigurationWarnings();
				}
			}
		}
		[Export] public EHighlightOn HighlightOn { get; set; } = EHighlightOn.Always;

		public enum EHighlightOn
		{
			Always,
			Focus,
			Closest
		}

		private MeshInstance3D _mesh;
		private ShaderMaterial _shader;
		private Interactable.Interactable _prop;

		public override void _Ready()
		{
			if (Engine.IsEditorHint()) return;

			Prop.Focused += OnFocus;
			Prop.Unfocused += OnFocusLost;
			Prop.Closest += OnClosest;
			Prop.NotClosest += OnNotClosest;
		}

		public override void _Process(double delta)
		{
			if (Engine.IsEditorHint()) return;

			if (!Enabled)
			{
				HideHighlighter();
				return;
			}
			if (HighlightOn == EHighlightOn.Always) ShowHighlighter();
		}

		private void ShowHighlighter()
		{
			if (Mesh == null || !Enabled) return;

			Mesh.MaterialOverlay = Shader;
		}

		private void HideHighlighter()
		{
			if (Mesh == null) return;

			Mesh.MaterialOverlay = null;
		}

		private void OnFocus(Interactor.Interactor prop)
		{
			if (HighlightOn == EHighlightOn.Focus) ShowHighlighter();
		}

		private void OnFocusLost(Interactor.Interactor prop)
		{
			if (HighlightOn == EHighlightOn.Focus) HideHighlighter();
		}

		private void OnClosest(Interactor.Interactor prop)
		{
			if (HighlightOn == EHighlightOn.Closest) ShowHighlighter();
		}

		private void OnNotClosest(Interactor.Interactor prop)
		{
			if (HighlightOn == EHighlightOn.Closest) HideHighlighter();
		}
	}
}
