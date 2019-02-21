using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;
public class PlayerMovementController : MonoBehaviour
{
    [Range (0.5f, 10.0f)]
    public float Speed = 5.0f;
    public float JumpForce = 200.0f;

    //bitmask
    public LayerMask GroundLayerMask;
    public Transform GroundCheck;

    private Transform _transform;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private PlayerHealthManager _playerHealth;

    private float _movementHorizontal;
    private float _movementVertical;
    private float _movementVerticalmove;

    private bool _isMoving = false;
    private bool _isMovingRight = true;

    private bool _isGrounded = false;

    private bool _isLadder = false;

    private int _playerLayer;
    private int _platformLayer;

    private bool Thisthing;

    void Awake()
    {
        _transform = transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerHealth = GetComponent<PlayerHealthManager>();

        _playerLayer = gameObject.layer;
        _platformLayer = LayerMask.NameToLayer("Platform");
}

    void Update()
    {
        _movementHorizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        if (_movementHorizontal != 0.0f)
        {
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
        }

        _animator.SetBool("IsMoving", _isMoving);

        _movementVertical = _rigidbody2D.velocity.y;

        _isGrounded = Physics2D.Linecast(_transform.position, GroundCheck.position, GroundLayerMask);

        if(_isGrounded && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            _rigidbody2D.AddForce(Vector2.up * JumpForce);
        }

        if (CrossPlatformInputManager.GetButtonUp ("Jump") && (_movementVertical > 0.0f))
            _movementVertical = 0.0f;

        _animator.SetBool("IsGrounded", _isGrounded);

        _rigidbody2D.velocity = new Vector2(_movementHorizontal * Speed, _movementVertical);

        Physics2D.IgnoreLayerCollision(_playerLayer, _platformLayer, CrossPlatformInputManager.GetAxis("Vertical") < 0 || (_movementVertical > 0.0f));
        /*
        if (Input.GetKey(KeyCode.S) && _movementVertical <= 0.0f)
            Physics2D.IgnoreLayerCollision(_playerLayer, _platformLayer);
        */
        /*
        Physics2D.IgnoreLayerCollision(_playerLayer, _platformLayer, Input.GetKey(KeyCode.S) && _movementVertical <= 0.0f);
        */
    }
    
    void LateUpdate()
    {
        Vector3 localScale = _transform.localScale;

        if (_movementHorizontal > 0.0f)
            _isMovingRight = true;
        else if (_movementHorizontal < 0.0f)
            _isMovingRight = false;

        if ((!_isMovingRight && (localScale.x > 0.0f)) || (_isMovingRight && (localScale.x < 0.0f)))
            localScale.x *= -1.0f;

        _transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
            _transform.parent = other.transform;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
            _transform.parent = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ladder")
        {
            _isLadder = true;
            _animator.SetBool("IsLadder", _isLadder);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ladder")
        {
            _isLadder = false;
            _animator.SetBool("IsLadder", _isLadder);
        }
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, GroundCheck.position);
    }
}
