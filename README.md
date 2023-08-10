<div align="center">
	<img src="./icon.png" width="320px" />
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
- `InteractableProp` - Allows to quickly create interactive objects with [outline]((https://godotshaders.com/shader/pixel-perfect-outline-shader/)) and [highlight]((https://godotshaders.com/shader/collectable-item-shining-highlight/)) effects. It uses the shaders mentioned in the [External assets](#external-assets) section.

## Usage

> Note: Detailed information on each class can be found in the built-in documentation, or in the individual source files.

You can find an example of using the above classes in the [examples folder](https://github.com/MASSHUU12/godot-interaction/tree/main/examples).

## External assets

The project uses the following shaders from the [Godot Shaders](https://godotshaders.com/shader/collectable-item-shining-highlight/) website:

- [Item Highlighter](https://godotshaders.com/shader/collectable-item-shining-highlight/)
- [Pixel Perfect outline Shader](https://godotshaders.com/shader/pixel-perfect-outline-shader/)

The shader code and all code snippets on [Godot Shaders](https://godotshaders.com/shader/collectable-item-shining-highlight/) website are under [MIT license](https://opensource.org/licenses/MIT).

## License

Licensed under [MIT license](./LICENSE).
