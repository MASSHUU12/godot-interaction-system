<div align="center">
	<h3>Interactor class</h3>
	<p />
	<p>Basic class, used to interact with <a href="../interactable/interactable.md">Interactable</a>.</p>
</div>


## Exported variables

| Name        | Type      | Description                                                            |
| ----------- | --------- | ---------------------------------------------------------------------- |
| ray_cast_3d | RayCast3D | Invokes `focused` and `unfocused` signals on the Interactable class.   |
| area_3d     | Area3D    | Invokes `closest` and `not_closest` signals on the Interactable class. |

## Usage

> Note: Interactive objects should be on a separate `Collision Layer` and `Collision Mask` than other objects in the game.

To use this class, you need to create a new script that extends it.

Then you need to find the interactive object on which you want to call the specific signal.

> Note: Make sure that `RayCast3D` or `Area3D` (depending on what you want to use) is passed to the class.

### Searching with RayCast3D

> `RayCast3D` should have property `collide_with_areas` set to `true`.

To find an interactive object using `RayCast3D` you can use the `Interactor` built-in class. It will return `Interactable` or `null` if there is no such object in range:

```ts
var raycasted: Interactable = get_raycasted_interactable()
```

### Searching with Area3D

To find an interactive object using `Area3D` you can use the `Interactor` built-in class. It will return `Interactable` or `null` if there is no such object in range:

```ts
var closest: Interactable = get_closest_interactable()
```

### Signals

Once you've acquired an interactive object, you can run the `signals` that go into `Interactable` on it. You can do this via built-in functions:

- `interact`: Used when `Interactor` interacts with `Interactable`.
- `focus`: Used when `RayCast3D` collide with `Interactable`.
- `unfocus`: Used when `RayCast3D` stops colliding with `Interactable`.
- `closest`: Used when specific `Interactable` is the closest `Interactable` to `Area3D`.
- `not_closest`: Used when specific `Interactable` is no longer the closest to `Area3D`.
