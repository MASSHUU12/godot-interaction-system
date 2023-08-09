# Change Log

All notable changes to this project will be documented in this file.

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
