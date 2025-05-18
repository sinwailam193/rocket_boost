using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustStrength = 1000f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        HandleThrust();
        HandleRotation();
    }

    private void HandleThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }

    private void HandleRotation()
    {
        float rotationValue = rotation.ReadValue<float>();

        if (rotationValue != 0)
        {
            Vector3 rotationDirection = rotationValue > 0 ? Vector3.forward : Vector3.back;

            transform.Rotate(rotationDirection * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
