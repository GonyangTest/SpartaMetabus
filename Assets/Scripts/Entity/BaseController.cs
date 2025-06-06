using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    protected Vector2 _movementDirection = Vector2.zero;
    protected Vector2 _lookDirection = Vector2.zero;
    
    public Vector2 MovementDirection {get {return _movementDirection;}}
    public Vector2 LookDirection {get {return _lookDirection;}}

    [SerializeField] private float _speed = 5f;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(_lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(_movementDirection);
    }

    protected virtual void HandleAction()
    {
    }

    private void Movement(Vector2 direction)
    {
        direction = direction * _speed;
        _rigidbody.velocity = direction;
    }   

    private void Rotate(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            return;
        }

        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotz) > 90f;
        _spriteRenderer.flipX = isLeft;
    }
}
