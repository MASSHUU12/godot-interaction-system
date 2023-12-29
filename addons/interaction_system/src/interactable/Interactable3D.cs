using Godot;

namespace InteractionSystem.Interactable
{
	public partial class Interactable3D : Interactable
	{
		[Export] public Area3D Area { get; set; }
	}
}
