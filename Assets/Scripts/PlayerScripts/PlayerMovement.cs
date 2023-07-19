using UnityEngine;

[RequireComponent(typeof(InputController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Variables")]
    [SerializeField] private float Speed;

    [Header("Movement boundary Variables")]
    [SerializeField] PolygonCollider2D backgroundCollider;

    // Internal References
    private InputController _inputController;
    private Animator _playerAnimator;

    private Rigidbody2D _rb;

    void Awake()
    {
        _inputController = GetComponent<InputController>();
        _playerAnimator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currDirection = _inputController.MovementInput;

        MovePlayer(currDirection);

        AnimateMovement(currDirection);
    }

    private void MovePlayer(Vector2 currDirection) {
        _rb.velocity = currDirection.normalized * Speed * Time.deltaTime;
    }


    private void AnimateMovement(Vector2 currDirection) {
        _playerAnimator.SetFloat("Horizontal",currDirection.x);
        _playerAnimator.SetFloat("Vertical",currDirection.y);
    }
}
