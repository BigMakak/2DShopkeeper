using UnityEngine;

[CreateAssetMenu(fileName = "Mouse Config", menuName = "ScriptableObjects/MouseConfig")]

public class MouseConfig : ScriptableObject
{

    public Texture2D MouseSprite;
    public bool Visibility = true;

    public CursorMode CursorMode = CursorMode.Auto;
}
