using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Rigidbody sphereRigidBody;
    [SerializeField] private float ballSpeed = 2f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private LayerMask groundLayer;

    //private bool IsGrounded()
    //{
    //    //return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    //    return Mathf.Abs(transform.position.y - 0.5f) < 0.1f;

    //}

    private bool isGrounded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground")) // Check if touching ground
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground")) // Check if leaving ground
        {
            isGrounded = false;
        }
    }

    private bool IsGrounded()
    {
        return isGrounded;
    }
    public void MoveBall(Vector2 input)
    {
        Vector3 inputXZPlane = new(input.x, 0, input.y);
        sphereRigidBody.AddForce(inputXZPlane * ballSpeed);
    }

    public void Jump()
    {
        if (IsGrounded()) // Prevents double jumping
        {
            sphereRigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    //void Start()
    //{
    //    //Debug.Log("Calling the start method");
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // Debug.Log("Calling the update method");
    //    Vector2 inputVector = Vector2.zero;


    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        inputVector += Vector2.up;
    //    }

    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        inputVector += Vector2.left;
    //    }

    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        inputVector += Vector2.down;
    //    }

    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        inputVector += Vector2.right;
    //    }

    //    Vector3 inputXZPlane = new Vector3(inputVector.x, 0, inputVector.y);
    //    sphereRigidBody.AddForce(inputXZPlane*ballSpeed);

    //    Debug.Log("Resultant Vector: " + inputVector);
    //    Debug.Log("Resultant 3D Vector: " + inputXZPlane);

    //}
}
