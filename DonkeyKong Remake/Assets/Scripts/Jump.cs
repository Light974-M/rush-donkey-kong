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
    private bool canUp = false;
    public static bool isHammerTaken = false;

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

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
        }


        if (canUp)
        {
            rb.useGravity = false;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
                transform.position += new Vector3(0, 0.1f, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
                transform.position += new Vector3(0, -0.1f, 0);
            }

            if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.UpArrow))
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }
            if (isScalingLeft)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
                    rb.useGravity = true;
                    canUp = false;
                    isScalingLeft = false;
                }
            }
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

            isScalingLeft = true;
            canUp = true;
        }
        else
        {
            
            isScalingRight = false;
            
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Marteau"))
        {
            isHammerTaken = true;
        }
    }
}
