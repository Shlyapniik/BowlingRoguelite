using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float deceleration = 25f;

    private Rigidbody rb;
    private Vector3 movementInput;
    private float currentSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementInput = new Vector3(horizontal, 0f, vertical).normalized;
    }

    private void FixedUpdate()
    {
        float targetSpeed = movementInput.magnitude * maxSpeed;

        float speedChange = movementInput.sqrMagnitude > 0f
            ? acceleration
            : deceleration;

        currentSpeed = Mathf.MoveTowards(
            currentSpeed,
            targetSpeed,
            speedChange * Time.fixedDeltaTime);

        Vector3 movement = movementInput * currentSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);
    }
}
