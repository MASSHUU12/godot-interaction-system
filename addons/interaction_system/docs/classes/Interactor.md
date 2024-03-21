<div align="center">
	<h3>Interactor</h1>
	<p>A base class for creating characters that interact with interactive objects.</p>
</div>

### Description

**Inherits**: Node

### Properties

| Type            | Name                 | Default |
| --------------- | -------------------- | ------- |
| Export float    | LongInteractionTime  | 0.3f    |
| bool            | IsFocused            | false   |
| Interactable    | Focusing             | null    |
| bool            | IsClosest            | false   |
| Interactable    | ClosestInteractable  | null    |
| protected Tiemr | LongInteractionTimer | -       |

### Methods

| Type                   | Definition                         |
| ---------------------- | ---------------------------------- |
| void                   | Interact (Interactable)            |
| void                   | LongInteract (Interactable)        |
| void                   | Focus (Interactable)               |
| void                   | Unfocus (Interactable)             |
| void                   | Closest (Interactable)             |
| void                   | NotClosest (Interactable)          |
| protected Interactable | GetInteractableFromPath (NodePath) |

### Signals

**InteractedWithInteractable** (Interactor)

**LongInteractedWithInteractable** (Interactor)

**ClosestToInteractableE** (Interactor)

**NotClosestToInteractable** (Interactor)

**FocusedOnInteractable** (Interactor)

**UnfocusedInteractable** (Interactor)

### Enumerations

**-**
