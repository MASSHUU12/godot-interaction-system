#if TOOLS
using Godot;

namespace InteractionSystem
{
	[Tool]
	public partial class InteractionSystem : EditorPlugin
	{
		private const string commonPath = "res://addons/interaction_system/src/";

		public override void _EnterTree()
		{
			var texture = GD.Load<Texture2D>("res://icon.png");

			AddCustomType("Interactable2D", "Area2D", GD.Load<Script>(commonPath + "interactable/Interactable2D.cs"), texture);
			AddCustomType("Interactable3D", "Area3D", GD.Load<Script>(commonPath + "interactable/Interactable3D.cs"), texture);
			AddCustomType("InteractableProp3D", "Area3D", GD.Load<Script>(commonPath + "interactable/InteractableProp3D.cs"), texture);

			AddCustomType("Interactor2D", "Node2D", GD.Load<Script>(commonPath + "interactor/Interactor2D.cs"), texture);
			AddCustomType("Interactor3D", "Node3D", GD.Load<Script>(commonPath + "interactor/Interactor3D.cs"), texture);

			AddCustomType("CharacterInteractor2D", "Node2D", GD.Load<Script>(commonPath + "interactor/character_interactor/CharacterInteractor2D.cs"), texture);
			AddCustomType("CharacterInteractor3D", "Node3D", GD.Load<Script>(commonPath + "interactor/character_interactor/CharacterInteractor3D.cs"), texture);
		}

		public override void _ExitTree()
		{
			RemoveCustomType("Interactable2D");
			RemoveCustomType("Interactable3D");
			RemoveCustomType("InteractableProp3D");

			RemoveCustomType("Interactor2D");
			RemoveCustomType("Interactor3D");

			RemoveCustomType("CharacterInteractor2D");
			RemoveCustomType("CharacterInteractor3D");
		}
	}
}
#endif
