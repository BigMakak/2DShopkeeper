using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Variables")]
    [SerializeField] private float Speed;

    // Internal References
    private InputController _inputController;
    private Animator _playerAnimator;

    void Awake()
    {
        _inputController = GetComponent<InputController>();
        _playerAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currDirection = _inputController.MovementInput;

        MovePlayer(currDirection);

        AnimateMovement(currDirection);
    }

    private void MovePlayer(Vector2 currDirection) {

        Vector3 moveDirection = new Vector3(currDirection.x, currDirection.y).normalized;
        this.transform.position += moveDirection * Speed * Time.deltaTime;
    }


    private void AnimateMovement(Vector2 currDirection) {
        _playerAnimator.SetFloat("Horizontal",currDirection.x);
        _playerAnimator.SetFloat("Vertical",currDirection.y);
    }


}
