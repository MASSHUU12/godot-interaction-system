#if TOOLS
using Godot;

namespace InteractionSystem;

[Tool]
public partial class InteractionSystem : EditorPlugin
{
	private const string commonPath = "res://addons/interaction_system/src/";

	public override void _EnterTree()
	{
		var icon = GD.Load<Texture2D>("res://addons/interaction_system/assets/textures/icon.png");

		AddCustomType("Interactable2D", "Node", GD.Load<Script>(commonPath + "interactable/Interactable2D.cs"), icon);
		AddCustomType("Interactable3D", "Node", GD.Load<Script>(commonPath + "interactable/Interactable3D.cs"), icon);

		AddCustomType("Interactor2D", "Node", GD.Load<Script>(commonPath + "interactor/Interactor2D.cs"), icon);
		AddCustomType("Interactor3D", "Node", GD.Load<Script>(commonPath + "interactor/Interactor3D.cs"), icon);

		AddCustomType("CharacterInteractor2D", "Node", GD.Load<Script>(commonPath + "interactor/character_interactor/CharacterInteractor2D.cs"), icon);
		AddCustomType("CharacterInteractor3D", "Node", GD.Load<Script>(commonPath + "interactor/character_interactor/CharacterInteractor3D.cs"), icon);

		AddCustomType("InteractableOutlineComponent", "Node", GD.Load<Script>(commonPath + "components/interactable_outline_component/InteractableOutlineComponent.cs"), icon);
		AddCustomType("InteractableHighlighterComponent", "Node", GD.Load<Script>(commonPath + "components/interactable_highlighter_component/InteractableHighlighterComponent.cs"), icon);
	}

	public override void _ExitTree()
	{
		RemoveCustomType("Interactable2D");
		RemoveCustomType("Interactable3D");

		RemoveCustomType("Interactor2D");
		RemoveCustomType("Interactor3D");

		RemoveCustomType("CharacterInteractor2D");
		RemoveCustomType("CharacterInteractor3D");

		RemoveCustomType("InteractableOutlineComponent");
		RemoveCustomType("InteractableHighlighterComponent");
	}
}
#endif
