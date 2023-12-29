using System.Collections.Generic;
using Godot;

namespace InteractionSystem.Interactable
{
	[Tool]
	public partial class InteractableProp3D : Interactable3D
	{
		[ExportGroup("Outline")]
		[Export] public bool OutlineEnabled { get; set; } = true;
		[Export]
		public MeshInstance3D OutlineMesh
		{
			get => _outlineMesh;
			set
			{
				if (value != _outlineMesh)
				{
					_outlineMesh = value;
					UpdateConfigurationWarnings();
				}
			}
		}

		[ExportGroup("Highlighter")]
		[Export] public bool HighlighterEnabled { get; set; } = false;
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
		public ShaderMaterial HighlighterMaterial
		{
			get => _highlighterMaterial;
			set
			{
				if (value != _highlighterMaterial)
				{
					_highlighterMaterial = value;
					UpdateConfigurationWarnings();
				}
			}
		}
		[Export] public EHighlightMoment HighlightMoment { get; set; } = EHighlightMoment.Always;

		public enum EHighlightMoment
		{
			Always,
			Closest
		}

		private MeshInstance3D _mesh;
		private MeshInstance3D _outlineMesh;
		private ShaderMaterial _highlighterMaterial = (ShaderMaterial)GD.Load<ShaderMaterial>(
				"res://addons/interaction_system/assets/shaders/item_highlighter.tres"
			).Duplicate();

		public override void _Ready()
		{
			base._Ready();

			Closest += OnClosestProp;
			NotClosest += OnNotClosestProp;
			Focused += OnFocusedProp;
			Unfocused += OnUnfocusedProp;

			if (HighlightMoment == EHighlightMoment.Always) ShowHighlighter();

			HideOutline();
		}

		public override string[] _GetConfigurationWarnings()
		{
			List<string> warnings = new();

			if (_outlineMesh == null)
			{
				var warning = "This node does not have the ability to display an outline. " +
					"Please add a MeshInstance3D to this node.";
				warnings.Add(warning);
			}

			if (_mesh == null)
			{
				var warning = "This node does not have a mesh. " +
					"Please add a MeshInstance3D to this node.";
				warnings.Add(warning);
			}

			warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

			return warnings.ToArray();
		}

		private void OnClosestProp(Interactor.Interactor interactor)
		{
			if (HighlightMoment == EHighlightMoment.Closest) ShowHighlighter();
		}

		private void OnNotClosestProp(Interactor.Interactor interactor)
		{
			if (HighlightMoment == EHighlightMoment.Closest) HideHighlighter();
		}

		private void OnFocusedProp(Interactor.Interactor interactor)
		{
			ShowOutline();
		}

		private void OnUnfocusedProp(Interactor.Interactor interactor)
		{
			HideOutline();
		}

		private void ShowOutline()
		{
			if (OutlineEnabled) _outlineMesh.Show();
		}

		private void HideOutline()
		{
			if (OutlineEnabled) _outlineMesh.Hide();
		}

		private void ShowHighlighter()
		{
			if (HighlighterEnabled) _mesh.MaterialOverlay = _highlighterMaterial;
		}

		private void HideHighlighter()
		{
			if (HighlighterEnabled) _mesh.MaterialOverlay = null;
		}
	}
}
