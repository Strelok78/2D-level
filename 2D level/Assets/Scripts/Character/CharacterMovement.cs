using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CharacterAnimationController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private CapsuleCollider2D _capsuleCollider2D;
    private CharacterAnimationController _characterAnimationController;
    private float _horizontalMovement;

    private void Awake()
    {
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _characterAnimationController = GetComponent<CharacterAnimationController>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal") * _speed;
        Run(_horizontalMovement, FacedRight(_horizontalMovement));

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
            Jump();

        if (!IsGrounded())
            _characterAnimationController.Jump(true);
        else
            _characterAnimationController.Jump(false);
    }

    public void StopMovement()
    {
        var movement = GetComponent<CharacterMovement>();
        movement.enabled = false;
    }

    private bool IsGrounded()
    {
        float angle = 0f;
        float rayLength = 0.1f;
        float boxCastY = 0.1f;
        Vector2 feetCenter = new Vector2(_capsuleCollider2D.bounds.min.x + _capsuleCollider2D.size.x / 2, _capsuleCollider2D.bounds.min.y);
        Vector2 feetSize = new Vector2(_capsuleCollider2D.size.x, boxCastY);

        RaycastHit2D groundRay = Physics2D.BoxCast(feetCenter, feetSize, angle, Vector2.down, rayLength, _layerMask);
        return groundRay.collider != null;
    }

    private bool FacedRight(float direction)
    {
        return direction < 0;
    }

    private void Run(float direction, bool isFlipped)
    {
        transform.Translate(direction * Time.deltaTime, 0, 0);

        if (direction != 0 && IsGrounded())
        {
            _spriteRenderer.flipX = isFlipped;
            _characterAnimationController.Run(true);
        }
        else
        {
            _characterAnimationController.Run(false);
        }
    }

    private void Jump()
    {
        _rigidbody2D.velocity = Vector2.up * _jumpForce;
    }
}