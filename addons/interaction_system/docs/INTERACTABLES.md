# Interactables

Interactables are objects that allow users to interact with them via interactors.

## Creating interactables

> [!NOTE]
> It is good practice to keep all collisions related to
> interactions on a separate layer/mask.

Interactables consist of at least two elements.
They must have an **Interactable2D/3D** node, and an **Area2D/3D** node.

## Usage

Using interactables comes down to simply listening for the appropriate signals.
Although the plugin is written in **C#** it is possible to use it via **GDScript**.

### GDScript example

```gdscript
extends Node2D


@onready var interactable: Node = $Interactable2D


func _ready() -> void:
    interactable.connect("Interacted", _on_interactable_interacted)


func _on_interactable_interacted(_interactor: Node) -> void:
    print("Interacted with the box!")
```

### C# example

```cs
using Godot;
using InteractionSystem;

public partial class InteractableBox : Node2D
{
    private Interactable2D? _interactable;

    public override void _Ready()
    {
        _interactable = GetNode<Interactable2D>("%Interactable2D");
        _interactable.Interacted += OnInteracted;
    }

    private void OnInteracted(Interactor _)
    {
        GD.Print("Interacted with the box!");
    }
}
```
