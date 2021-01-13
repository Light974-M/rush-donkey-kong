using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public static bool canUp = false;
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

            if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }
        }
    }







    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Tonneau"))
        {
            if(!isHammerTaken)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Echelle"))
        {
            if(!isHammerTaken)
            {

            }
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Marteau"))
        {
            isHammerTaken = true;
        }
    }
}
