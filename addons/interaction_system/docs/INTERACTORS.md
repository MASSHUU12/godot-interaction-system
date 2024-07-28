# Interactors

Interactors are objects that allow users to interact with interactables.

## Creating interactors

> [!NOTE]
> It is good practice to keep all collisions related to
> interactions on a separate layer/mask.

Depending on your needs, this plugin provides both specialized and general interactors.

### Specialized interactors

- **CharacterInteractor2D/3D**: Interactor adapted to the player's character.
- **MouseInteractor2D**: Allows for interaction with the mouse cursor, such as in point and click games.

### General interactors

- Interactor
- InteractorSpatial
- Interactor2D
- Interactor3D

## Usage

Using interactors comes down to simply listening for the appropriate signals.
Although the plugin is written in **C#** it is possible to use it via **GDScript**.

### GDScript example

```gdscript
extends CharacterBody2D


@onready var interactor: Node = $Interactor2D


func _ready() -> void:
    interactor.connect("InteractedWithInteractable", _on_interactor_interacted)


func _on_interactor_interacted(interactable: Node) -> void:
    print("Interacting with: " + str(interactable))
```

### C# example

```cs
using Godot;
using InteractionSystem;

public partial class Player : CharacterBody2D
{
    private CharacterInteractor2D? _interactor;

    public override void _Ready()
    {
        _interactor = GetNode<CharacterInteractor2D>("%CharacterInteractor2D");
        _interactor.InteractedWithInteractable += OnInteracted;
    }

    private void OnInteracted(Interactable interactable)
    {
        GD.Print($"Interacted with: {interactable.Name}");
    }
}
```
