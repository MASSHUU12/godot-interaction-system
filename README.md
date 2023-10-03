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
-   [`Interactable2D/3D`](#interactable2d3d): Used to create `interactive` objects.
-   [`InteractableProp3D`](#interactableprop3d) - Allows to quickly create interactive objects with `outline` and `highlight` effects.

## Prerequisites

-   [.NET SDK](https://dotnet.microsoft.com/download)
-   [.NET enabled Godot](https://godotengine.org/download)

## Usage

> [!NOTE]
> Detailed information on each class can be found in the individual source files.

You can find an example of using the above classes in the [examples](./examples) folder.

It is a good practice to put everything related to the interaction system on a separate layer/mask.

### Interactor2D/3D

A base class for creating characters that interact with interactive objects.

If you want to create a simple `player character`, it is best to use the already prepared [`CharacterInteractor2D/3D`](#characterinteractor2d3d) class.

Requires passing `RayCast2D/3D` (Focused/Unfocused signals) and/or `Area2D/3D` (Closest/NotClosest signals) in exported variables.

| Signal                       | Parameter                                                |
| ---------------------------- | -------------------------------------------------------- |
| **Interacted**               | Interactable that Interactor interacted with             |
| **ClosestToInteractable**    | Interactable that is closest to the Interactor           |
| **NotClosestToInteractable** | Interactable that is no longer closest to the Interactor |
| **FocusedOnInteractable**    | Interactable that Interactor is looking at               |
| **UnfocusedInteractable**    | Interactable that is no longer looked at by Interactor   |

### CharacterInteractor2D/3D

Class inheriting from `Interactor2D/3D` tailored to add interaction capabilities for `player characters`.

It has the same signals and exported variables as the parent class moreover it requires the name of the action to be used for interaction and allows you to customize the behavior of RayCast and Area.

### Interactable2D/3D

A basic class used to create `interactive` objects that `Interactor` can interact with.

| Signal         | Parameter                                                         |
| -------------- | ----------------------------------------------------------------- |
| **Interacted** | Interactor that interacted with the object                        |
| **Closest**    | Interactor, to which the object is the nearest Interactable       |
| **NotClosest** | Interactor, to which the object is no longer nearest Interactable |
| **FocusedOn**  | Interactor that is looking at the object                          |
| **Unfocused**  | Interactor that is no longer looking at the object                |

### InteractableProp3D

A class, inheriting from `Interactable3D`, is used to simply create interactive objects with `outline` and/or `highlight` effects.

#### Outline

Outline requires the creation of a `MeshInstance3D` to be used as the outline.

You can easily do this by selecting the `MeshInstance3D` of your object, clicking `Mesh` in the menu and selecting `Create Outline Mesh`.

#### Highlight

Highlight by default uses [this shader](https://godotshaders.com/shader/collectable-item-shining-highlight/) shared under [MIT license](https://opensource.org/licenses/MIT).

You can change the shader in use using the exported `Highlighter Material` variable.

## Debugging

### Debugging via VSCode

In the [.vscode](./.vscode) folder, the configuration for debugging `Godot` projects is prepared.

All you have to do is pass the `path` to the `Godot executable` file in the [launch.json](./.vscode/launch.json) file and press F5.

## External assets

The project uses the following shaders from the [Godot Shaders](https://godotshaders.com/shader/collectable-item-shining-highlight/) website under [MIT license](https://opensource.org/licenses/MIT):

-   [Item Highlighter](https://godotshaders.com/shader/collectable-item-shining-highlight/)

## License

Licensed under [MIT license](./LICENSE).
