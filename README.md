<div align="center">
	<img src="./icon.png" width="320px" />
	<h3>Godot Interaction System</h3>
	<p />
	<p>A simple interaction system for Godot 4. Works with 2D and 3D.</p>
</div>

> [!NOTE]
> As of version 2.0, the extension is written in C#.
> The version in GDScript is no longer supported, you can find the latest version written in GDScript [here](https://github.com/MASSHUU12/godot-interaction-system/tree/v1.5.0).

## Features

-   [`Interactor2D/3D`](#interactor2d3d): Used to interact with `Interactables`.
-   [`CharacterInteractor2D/3D`](#characterinteractor2d3d): Simplifies the process of creating a `player character`.
-   `Interactable2D/3D`: Used to create `interactive` objects.
-   `InteractableProp3D` - Allows to quickly create interactive objects with `outline` and [highlight](https://godotshaders.com/shader/collectable-item-shining-highlight/) effects.

## Prerequisites

-   [.NET SDK](https://dotnet.microsoft.com/download)
-   [.NET enabled Godot](https://godotengine.org/download)

## Usage

> [!NOTE]
> Detailed information on each class can be found in the individual source files.

You can find an example of using the above classes [here](./scenes).

It is a good practice to put everything related to the interaction system on a separate layer/mask.

### Interactor2D/3D

A base class for creating characters that interact with interactive objects.

If you want to create a simple `player character`, it is best to use the already prepared [`CharacterInteractor2D/3D`](#characterinteractor2d3d) class.

Requires passing `RayCast2D/3D` (Focused/Unfocused signals) and/or `Area2D/3D` (Closest/NotClosest signals) in exported variables.

| Signal                   | Parameter                                                |
| ------------------------ | -------------------------------------------------------- |
| Interacted               | Interactable that Interactor interacted with             |
| ClosestToInteractable    | Interactable that is closest to the Interactor           |
| NotClosestToInteractable | Interactable that is no longer closest to the Interactor |
| FocusedOnInteractable    | Interactable that Interactor is looking at               |
| UnfocusedInteractable    | Interactable that is no longer looked at by Interactor   |

### CharacterInteractor2D/3D

Class inheriting from `Interactor2D/3D` tailored to add interaction capabilities for `player characters`.

It has the same signals and exported variables as the parent class moreover it requires the name of the action to be used for interaction and allows you to customize the behavior of RayCast and Area.

## Debugging

### Debugging via VSCode

In the [.vscode](./.vscode) folder, the configuration for debugging `Godot` projects is prepared.

All you have to do is pass the `path` to the `Godot executable` file in the [launch.json](./.vscode/launch.json) file and press F5.

## External assets

The project uses the following shaders from the [Godot Shaders](https://godotshaders.com/shader/collectable-item-shining-highlight/) website under [MIT license](https://opensource.org/licenses/MIT):

-   [Item Highlighter](https://godotshaders.com/shader/collectable-item-shining-highlight/)

## License

Licensed under [MIT license](./LICENSE).
