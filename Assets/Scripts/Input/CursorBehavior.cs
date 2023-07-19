using UnityEngine;

public class CursorBehavior : MonoBehaviour 
{
    [SerializeField] private MouseConfig defaultMouse;

    [SerializeField] private MouseConfig clickMouse;

    void Start()
    {
        SetMouseConfig(defaultMouse);   
    }

    private void SetMouseConfig(MouseConfig config) 
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = config.Visibility;

        Cursor.SetCursor(config.MouseSprite,Vector2.zero,config.CursorMode);
    }
}
