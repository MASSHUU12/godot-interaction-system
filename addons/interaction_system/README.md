<div align="center">
 <img src="./assets/textures/icon.png" width="320px" />
 <h3>Godot Interaction System</h3>
 <p />
 <p>A simple 2D/3D interaction system for Godot 4.</p>
</div>

> [!NOTE]
> As of version 2.0, the extension is written in C#.
> The version in GDScript is no longer supported, you can find the latest version written in GDScript [here](https://github.com/MASSHUU12/godot-interaction-system/tree/v1.5.0).

## Prerequisites

- [.NET SDK 6^](https://dotnet.microsoft.com/download)
- [.NET enabled Godot 4^](https://godotengine.org/download)

Make sure to update your [.csproj](./docs/USAGE.md).

## Features

- Simple interaction system (2D/3D/mouse in 2D)
- Small size footprint (< 32 KB)
- Components:
  - `InteractableOutlineComponent`
  - `InteractableHighlighterComponent`

## Documentation

Instructions on how to get started can be found in the [USAGE.md](./docs/USAGE.md) file.

You can find the documentation in the [docs](./docs/) folder
and example in the [example](../../examples/) folder.

## External assets

The project uses the following shaders from the [Godot Shaders](https://godotshaders.com/shader/collectable-item-shining-highlight/) website under [MIT license](https://opensource.org/licenses/MIT):

- [Item Highlighter](https://godotshaders.com/shader/collectable-item-shining-highlight/) used in example scene.

## License

Licensed under [MIT license](./LICENSE).
