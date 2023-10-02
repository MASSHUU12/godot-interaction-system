<div align="center">
	<img src="./icon.png" width="320px" />
	<h3>Godot Interaction System</h3>
	<p />
	<p>A simple interaction system for Godot 4. Works with 2D and 3D.</p>
</div>

> [!NOTE]
> As of version 2.0, the extension is written in C#.
> The version in GDScript is no longer supported, you can find the latest version written in GDScript [here](https://github.com/MASSHUU12/godot-interaction-system/tree/v1.5.0).

## Prerequisites

-   [.NET SDK](https://dotnet.microsoft.com/download)
-   [.NET enabled Godot](https://godotengine.org/download)

## Features

-   `Interactor2D`: Class used to interact with `Interactable2D`.
-   `Interactor3D`: Class used to interact with `Interactable3D`.
-   `CharacterBody3DInteractor`: Class tailored for `CharacterBody3D`, it simplifies the process of creating a player character.
-   `CharacterBody2DInteractor`: Class tailored for `CharacterBody2D`, it simplifies the process of creating a player character.
-   `Interactable2D`: Class used to create interactive objects in 2D space.
-   `Interactable3D`: Class used to create interactive objects in 3D space.
-   `InteractableProp` - Allows to quickly create interactive objects with [outline](<(https://godotshaders.com/shader/pixel-perfect-outline-shader/)>) and [highlight](<(https://godotshaders.com/shader/collectable-item-shining-highlight/)>) effects. It uses the shaders mentioned in the [External assets](#external-assets) section. Works in 3D.

## Usage

> [!NOTE]
> Detailed information on each class can be found in the individual source files.

You can find an example of using the above classes in the [examples folder](https://github.com/MASSHUU12/godot-interaction/tree/main/examples).

## Debugging

### Debugging via VSCode

In the [.vscode](./.vscode) folder, the configuration for debugging `Godot` projects is prepared.

All you have to do is pass the `path` to the `Godot executable` file in the [launch.json](./.vscode/launch.json) file and press F5.

## External assets

The project uses the following shaders from the [Godot Shaders](https://godotshaders.com/shader/collectable-item-shining-highlight/) website under [MIT license](https://opensource.org/licenses/MIT):

-   [Item Highlighter](https://godotshaders.com/shader/collectable-item-shining-highlight/)

## License

Licensed under [MIT license](./LICENSE).
