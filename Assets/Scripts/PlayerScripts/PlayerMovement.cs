using UnityEngine;

[RequireComponent(typeof(InputController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Variables")]
    [SerializeField] private float Speed;

    [SerializeField] SpriteRenderer backgroundSprite;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currDirection = _inputController.MovementInput;

        // TODO continuar aqui para verificar os bounds maximos da imagem de background
        // De momento parte um bocado o jogo, o jogador continuar a andar para frente para sempre
        if(this.transform.position.x > backgroundSprite.sprite.bounds.max.x) 
        {
            return;
        }

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

    private void LimitePlayerMovement() 
    {
        
    }


}
