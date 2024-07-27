#if TOOLS
using Godot;

namespace InteractionSystem;

[Tool]
public partial class InteractionSystem : EditorPlugin
{
    public override void _EnterTree()
    {
        string pluginPath = GetPluginPath();
        Texture2D icon = GD.Load<Texture2D>(pluginPath + "/assets/textures/icon.png");

        AddCustomType(
            "Interactable2D",
            "Node",
            GD.Load<Script>(pluginPath + "/src/interactable/Interactable2D.cs"),
            icon
        );
        AddCustomType(
            "Interactable3D",
            "Node",
            GD.Load<Script>(pluginPath + "/src/interactable/Interactable3D.cs"),
            icon
        );
        AddCustomType(
            "Interactor2D",
            "Node",
            GD.Load<Script>(pluginPath + "/src/interactor/Interactor2D.cs"),
            icon
        );
        AddCustomType(
            "Interactor3D",
            "Node",
            GD.Load<Script>(pluginPath + "/src/interactor/Interactor3D.cs"),
            icon
        );
        AddCustomType(
            "CharacterInteractor2D",
            "Node",
            GD.Load<Script>(
                pluginPath + "/src/interactor/character_interactor/CharacterInteractor2D.cs"
            ),
            icon
        );
        AddCustomType(
            "CharacterInteractor3D",
            "Node",
            GD.Load<Script>(
                pluginPath + "/src/interactor/character_interactor/CharacterInteractor3D.cs"
            ),
            icon
        );
        AddCustomType(
            "InteractableOutlineComponent",
            "Node",
            GD.Load<Script>(
                pluginPath + "/src/components/interactable_outline_component/InteractableOutlineComponent.cs"
            ),
            icon
        );
        AddCustomType(
            "InteractableHighlighterComponent",
            "Node",
            GD.Load<Script>(
                pluginPath + "/src/components/interactable_highlighter_component/InteractableHighlighterComponent.cs"
            ),
            icon
        );
        AddCustomType(
            "MouseInteractor2D",
            "Node",
            GD.Load<Script>(pluginPath + "/src/interactor/MouseInteractor2D.cs"),
            icon
        );
    }

    public override void _ExitTree()
    {
        RemoveCustomType("Interactable2D");
        RemoveCustomType("Interactable3D");

        RemoveCustomType("Interactor2D");
        RemoveCustomType("Interactor3D");

        RemoveCustomType("CharacterInteractor2D");
        RemoveCustomType("CharacterInteractor3D");

        RemoveCustomType("InteractableOutlineComponent");
        RemoveCustomType("InteractableHighlighterComponent");

        RemoveCustomType("MouseInteractor2D");
    }

    private string GetPluginPath()
    {
        return GetScript().As<Script>().ResourcePath.GetBaseDir();
    }
}
#endif
