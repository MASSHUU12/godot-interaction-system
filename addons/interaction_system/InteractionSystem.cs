#if TOOLS
using Godot;

[Tool]
public partial class InteractionSystem : EditorPlugin
{
	public override void _EnterTree()
	{
		var texture = GD.Load<Texture2D>("res://icon.png");
		var script = GD.Load<Script>("res://addons/interaction_system/systems/interaction/interactable/Interactable3D.cs");
		AddCustomType("Interactable3D", "Area3D", script, texture);

		script = GD.Load<Script>("res://addons/interaction_system/systems/interaction/interactable/Interactable2D.cs");
		AddCustomType("Interactable2D", "Area2D", script, texture);

		script = GD.Load<Script>("res://addons/interaction_system/systems/interaction/interactor/Interactor3D.cs");
		AddCustomType("Interactor3D", "Node3D", script, texture);
	}

	public override void _ExitTree()
	{
		RemoveCustomType("Interactable3D");
		RemoveCustomType("Interactable2D");

		RemoveCustomType("Interactor3D");
	}
}
#endif
