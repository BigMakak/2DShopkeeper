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
        Vector2 nextPost = _rb.position + currDirection.normalized * Speed * Time.deltaTime;

        isPlayerInBounds(ref nextPost);

        _rb.position = nextPost;
    }


    private void AnimateMovement(Vector2 currDirection) {
        _playerAnimator.SetFloat("Horizontal",currDirection.x);
        _playerAnimator.SetFloat("Vertical",currDirection.y);
    }

    private void isPlayerInBounds(ref Vector2 nextPosition) 
    {
        Bounds backgroundBounds = this.backgroundCollider.bounds;

        if(nextPosition.x > backgroundBounds.max.x)
        {
            nextPosition = new Vector2(backgroundBounds.max.x, nextPosition.y);
        }

        if(nextPosition.x < backgroundBounds.min.x) 
        {
            nextPosition = new Vector2(backgroundBounds.min.x, nextPosition.y);
        }

        if(nextPosition.y > backgroundBounds.max.y)
        {
            nextPosition = new Vector2(nextPosition.x, backgroundBounds.max.y);
        }

        if(nextPosition.y < backgroundBounds.min.y) 
        {
            nextPosition = new Vector2(nextPosition.x, backgroundBounds.min.y);
        }
    }
}
