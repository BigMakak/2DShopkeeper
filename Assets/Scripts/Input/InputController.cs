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
        Debug.Log("Input value: " + inputValue.Get<Vector2>());

        MovementInput = inputValue.Get<Vector2>();
    }
    #endif
}
