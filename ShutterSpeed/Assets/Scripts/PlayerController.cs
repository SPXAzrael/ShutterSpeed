using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float laneClamp = 3f;
    [SerializeField] LayerMask groundLayer;

    CapsuleCollider collider;

    private Rigidbody rb;
    public float moveSpeed = 5f;
    Vector2 movement;
    bool IsSliding = false;

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded() && context.started)
        {
            Vector3 playerVelocity = rb.linearVelocity;
            playerVelocity.y = 0f;
            rb.linearVelocity = playerVelocity;

            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    public void Slide(InputAction.CallbackContext context)
    {
        if (!IsSliding && IsGrounded() && context.started)
        {
            StartCoroutine(SlideRoutine());
        }
    }

    private void HandleMovement()
    {
        Vector3 currentPosition = transform.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, 0f);
        Vector3 newPosition = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime); 
        newPosition.x = Mathf.Clamp(newPosition.x, -laneClamp, laneClamp);
        rb.MovePosition(newPosition);
    }

    private bool IsGrounded(float length = 0.2f)
    {
        Vector3 raycastOriginFirst = transform.position;
        raycastOriginFirst.y -= collider.height / 2f;
        raycastOriginFirst.y += 0.1f;

        Vector3 raycastOriginSecond = raycastOriginFirst;
        raycastOriginFirst -= transform.forward * 0.2f;
        raycastOriginSecond += transform.forward * 0.2f;

        if (Physics.Raycast(raycastOriginFirst, Vector3.down, out RaycastHit hit, length, groundLayer)||
            (Physics.Raycast(raycastOriginSecond, Vector3.down, out RaycastHit hit2, length, groundLayer)))
        {
            return true;
        }
        return false;

    }
    private IEnumerator SlideRoutine()
    {
        IsSliding = true;
        Vector3 originalColliderCentre = collider.center;
        Vector3 newColliderCentre = originalColliderCentre;
        collider.height /= 3;
        newColliderCentre.y -= collider.height / 2;
        collider.center = newColliderCentre;

        yield return new WaitForSeconds(1f);

        collider.height *= 3;
        collider.center = originalColliderCentre;
        IsSliding = false;
    }

}
