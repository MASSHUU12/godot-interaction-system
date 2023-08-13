# Change Log

All notable changes to this project will be documented in this file.

## [1.5.0 - 2023-08-13]

### Added

- Five new signals for `CharacterBody2DInteractor` and `CharacterBody3DInteractor`:
  - `interacted_with_interactable`
  - `focused_on_interactable`
  - `unfocused_interactable`
  - `closest_interactable`
  - `not_closest_interactable`

### Changed

- Updated examples to reflect new changes.

## [1.4.0 - 2023-08-12]

### Added

- Support for `2D`.
- `Interactor2D` class.
- `Interactor3D` class.
- `Interactable2D` class.
- `Interactable3D` class.
- `CharacterBody2DInteractor` class.

### Changed

- Code refactoring.
- Better directory structure.
- Removed `Interactor` class.
- Removed `Interactable` class.
- `README` adjusted to reflect new changes.

## [1.3.0 - 2023-08-10]

### Added

- `InteractableProp` is fully functional, but it is still in an `early` version, a lot can change.
- `Example 3` showing how `InteractableProp` works.

### Changed

- Renamed the main folder and the main file.
- New plugin logo.

## [1.2.0 - 2023-08-09]

### Added

- `CharacterBody3DInteractor` has the ability to trigger the `interacted` signal via `Area3D` on collision or when the interaction button is pressed.
- `CharacterBody3DInteractor` has the option to disable `RayCast3D`'s ability to run `interacted` signal.
- Entirely new examples.

### Changed

- Removed external documentation in favor of that built into the extension.
- `InteractableProp` is under `Interactable` in node tree (Still WIP).

## [1.1.0 - 2023-08-08]

### Changed

- Fully reworked examples.
- More extensive documentation.

### Fixed

- Warnings from `CharacterBody3DInteractor` now displays correctly.
- `Area3D` in an example do not correctly detect `Interactable`.
- Plugin does not load due to errors after removing the old icon.
