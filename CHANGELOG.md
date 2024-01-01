# Change Log

All notable changes to this project will be documented in this file.

## [2.3.0 - 2024-01-01]

### Added

-   IsFocused, Focusing, IsClosest & ClosestInteractable properties to the Interactor class.
-   Example scene: 3DExample.
-   Example interactables: Box, OutlineBox, HighlightBox, AllInOneBox.

### Changed

-   Methods: Interact, Focus, Unfocus, Closest, NotClosest
    are no longer static & do not accept Interactor as second argument.

### Removed

-   Overloads in Interactor2D/3D for methods: Interact, Focus, Unfocus, Closest, NotClosest.
-   Example scenes: ExampleInteractable3D, ExampleInteractableProp3D.
-   Example interactables: InteractableBox, InteractablePropBox.

## [2.2.0 - 2023-12-31]

### Added

-   InteractableOutlineComponent & InteractableHighlighterComponent.
-   Docs for InteractableOutlineComponent & InteractableHighlighterComponent.

### Changed

-   Metadata added to Area2D/3D takes up less space by writing the path to Interactable instead of a reference.

### Fixed

-   Interactable2D/3D tried to set metadata for Area2D/3D on \_Ready when running in editor.

### Removed

-   InteractableProp3D.

## [2.1.0 - 2023-12-29]

### Added

-   Copy of README.md & LICENSE in addon's folder.
-   Configuration warnings for Interactable2D/3D.

### Changed

-   Godot SDK version to 4.3.0-dev.1.
-   Improved folder structure.
-   Updated meshes to use new format.
-   Moved Interactables & Interactors under namespaces.
-   EOL to LF.
-   Moved documentation to the docs folder.
-   The exported ZIP file will contain only the addons and examples folders.
-   Removed unnecessary comments.
-   Interactor class inherits from Node.
-   Interactor2D/3D inherits from Interactor.
-   Interactable class inherits from Node.
-   Interactable2D/3D inherits from Interactable.
-   Documentation has been expanded.

### Removed

-   IInteractor interface.
-   GetRayCastedInteractable method from Interactor.
-   IInteractable interface.

## [2.0.0 - 2023-10-03]

### Added

-   New examples.
-   Plugin implementation in C#.
-   More documentation sections in README.
-   The ability to debug a plugin (or a game created with it) via VS Code.

### Changed

-   Renamed some signals.
-   Renamed some classes.
-   Renamed entries in Input Map.
-   Renamed/changed some exported variables.
-   The way the highlighter is added to the object has been significantly simplified.
-   The way the outline is added to an interactive object has been changed (the shader is no longer needed).

### Removed

-   Old examples.
-   Outline shader.
-   Plugin implementation in GDScript.

## [1.5.0 - 2023-08-13]

### Added

-   Five new signals for `CharacterBody2DInteractor` and `CharacterBody3DInteractor`:
    -   `interacted_with_interactable`
    -   `focused_on_interactable`
    -   `unfocused_interactable`
    -   `closest_interactable`
    -   `not_closest_interactable`

### Changed

-   Updated examples to reflect new changes.

## [1.4.0 - 2023-08-12]

### Added

-   Support for `2D`.
-   `Interactor2D` class.
-   `Interactor3D` class.
-   `Interactable2D` class.
-   `Interactable3D` class.
-   `CharacterBody2DInteractor` class.

### Changed

-   Code refactoring.
-   Better directory structure.
-   Removed `Interactor` class.
-   Removed `Interactable` class.
-   `README` adjusted to reflect new changes.

## [1.3.0 - 2023-08-10]

### Added

-   `InteractableProp` is fully functional, but it is still in an `early` version, a lot can change.
-   `Example 3` showing how `InteractableProp` works.

### Changed

-   Renamed the main folder and the main file.
-   New plugin logo.

## [1.2.0 - 2023-08-09]

### Added

-   `CharacterBody3DInteractor` has the ability to trigger the `interacted` signal via `Area3D` on collision or when the interaction button is pressed.
-   `CharacterBody3DInteractor` has the option to disable `RayCast3D`'s ability to run `interacted` signal.
-   Entirely new examples.

### Changed

-   Removed external documentation in favor of that built into the extension.
-   `InteractableProp` is under `Interactable` in node tree (Still WIP).

## [1.1.0 - 2023-08-08]

### Changed

-   Fully reworked examples.
-   More extensive documentation.

### Fixed

-   Warnings from `CharacterBody3DInteractor` now displays correctly.
-   `Area3D` in an example do not correctly detect `Interactable`.
-   Plugin does not load due to errors after removing the old icon.
