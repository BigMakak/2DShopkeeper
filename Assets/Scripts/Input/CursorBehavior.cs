using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    [SerializeField] private MouseConfig defaultMouseConfig;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = defaultMouseConfig.Visibility;

        Cursor.SetCursor(defaultMouseConfig.MouseSprite,Vector2.zero,defaultMouseConfig.CursorMode);
    }
}
