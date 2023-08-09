<div align="center">
	<h3>Godot Interaction System</h3>
	<p />
	<p>A simple interaction system for Godot 4. Currently supports only 3D.</p>
</div>

## Features

This project adds new nodes to Godot, so you can easily add an interaction system to your own game.

The project adds the following nodes:

- `Interactor`: Basic class, used to interact with `Interactable`.
- `CharacterBody3DInteractor`: A specialized class tailored for `CharacterBody3D`, it simplifies the process of creating a player character.
- `Interactable`: A basic class used to create interactive objects.
- InteractableProp - Currently, it does nothing (WIP).

## Usage

> Note: Detailed information on each class can be found in the built-in documentation, or in the individual source files.

You can find an example of using the above classes in the [example folder](https://github.com/MASSHUU12/godot-interaction/tree/main/example).

## External assets

The project uses the following shaders from the [Godot Shaders](https://godotshaders.com/shader/collectable-item-shining-highlight/) website:

- [Item Highlighter](https://godotshaders.com/shader/collectable-item-shining-highlight/)
- [Pixel Perfect outline Shader](https://godotshaders.com/shader/pixel-perfect-outline-shader/)

The shader code and all code snippets on [Godot Shaders](https://godotshaders.com/shader/collectable-item-shining-highlight/) website are under [MIT license](https://opensource.org/licenses/MIT).

## License

Licensed under [MIT license](./LICENSE).
