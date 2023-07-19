using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public Vector2 MovementInput;

    #if ENABLE_INPUT_SYSTEM 
    public void OnMove(InputValue inputValue) 
    {
        MovementInput = inputValue.Get<Vector2>();
    }
    #endif
}
