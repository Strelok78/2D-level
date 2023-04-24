using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CharacterAnimationController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    private CharacterAnimationController _characterAnimationController;
    private float _horizontalMovement;

    private void Awake()
    {
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _characterAnimationController = GetComponent<CharacterAnimationController>();
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

    private bool IsGrounded()
    {
        float angle = 0f;
        float rayLength = 0.1f;

        RaycastHit2D groundRay = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.size, angle, Vector2.down, rayLength, _layerMask);
        Debug.DrawRay(_boxCollider.bounds.center, Vector2.down * (_boxCollider.size.y + rayLength), Color.red);

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