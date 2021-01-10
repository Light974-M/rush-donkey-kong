using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public static bool isScalingLeft = false;
    public static bool isScalingRight = false;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    private bool isLeft = true;

    public bool isGrounded;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Tonneau"))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Echelle"))
        {
            if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                isScalingLeft = true;

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    isScalingLeft = false;
                }
            }

            if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                isScalingRight = true;

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    isScalingRight = false;
                }
            }

            if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                isScalingRight = false;
                isScalingLeft = false;
            }


            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0.1f, 0);
            }

            isScalingLeft = true;
        }
        else
        {
            isScalingLeft = false;
            isScalingRight = false;
        }
    }
}
