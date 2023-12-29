#if TOOLS
using Godot;

namespace InteractionSystem
{
	[Tool]
	public partial class InteractionSystem : EditorPlugin
	{
		public override void _EnterTree()
		{
			var texture = GD.Load<Texture2D>("res://icon.png");
			var script = GD.Load<Script>("res://addons/interaction_system/src/interactable/Interactable3D.cs");
			AddCustomType("Interactable3D", "Area3D", script, texture);

			script = GD.Load<Script>("res://addons/interaction_system/src/interactable/InteractableProp3D.cs");
			AddCustomType("InteractableProp3D", "Area3D", script, texture);

			script = GD.Load<Script>("res://addons/interaction_system/src/interactable/Interactable2D.cs");
			AddCustomType("Interactable2D", "Area2D", script, texture);

			script = GD.Load<Script>("res://addons/interaction_system/src/interactor/Interactor3D.cs");
			AddCustomType("Interactor3D", "Node3D", script, texture);

			script = GD.Load<Script>("res://addons/interaction_system/src/interactor/Interactor2D.cs");
			AddCustomType("Interactor2D", "Node2D", script, texture);

			script = GD.Load<Script>("res://addons/interaction_system/src/interactor/character_interactor/CharacterInteractor3D.cs");
			AddCustomType("CharacterInteractor3D", "Node3D", script, texture);

			script = GD.Load<Script>("res://addons/interaction_system/src/interactor/character_interactor/CharacterInteractor2D.cs");
			AddCustomType("CharacterInteractor2D", "Node2D", script, texture);
		}

		public override void _ExitTree()
		{
			RemoveCustomType("Interactable3D");
			RemoveCustomType("InteractableProp3D");
			RemoveCustomType("Interactable2D");

			RemoveCustomType("Interactor3D");
			RemoveCustomType("Interactor2D");

			RemoveCustomType("CharacterInteractor3D");
			RemoveCustomType("CharacterInteractor2D");
		}
	}
}
#endif
