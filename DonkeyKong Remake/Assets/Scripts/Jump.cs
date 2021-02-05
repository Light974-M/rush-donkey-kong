using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 4.0f;
    public static bool canUp = false;
    public static bool isHammerTaken = false;
    public static bool canPressUp = false;
    private bool returnToNormal = false;
    public static bool isTop = false;
    public static bool barriereGauche = false;
    public static bool barriereDroite = false;
    public static bool deathAnimationStart = false;
    public int timer = 0;
    public static int life = 3;

    public bool isGrounded;
    Rigidbody rb;


    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }







    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void OnCollisionExit()
    {
        isGrounded = false;
    }







    void Update()
    {

        returnToNormal = HammerControler.returnToNormal;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


        if (canUp)
        {
            rb.useGravity = false;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePosition;
                transform.position += new Vector3(0, 0.1f, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePosition;
                transform.position += new Vector3(0, -0.1f, 0);
            }

            if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            }
        }
        else
        {
            rb.useGravity = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }


        if(canPressUp)
        {
            if(isTop)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    canUp = true;
                    //canPressUp = false;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    canUp = true;
                    //canPressUp = false;
                }
            }
        }

        if (returnToNormal)
        {
            isHammerTaken = false;
        }


        if(barriereGauche)
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                barriereGauche = false;
            }
        }

        if (barriereDroite)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                barriereDroite = false;
            }
        }


        if(deathAnimationStart)
        {
            Time.timeScale = 0;

            if(timer <400)
            {
                Debug.Log("animation en cours");
                timer += 1;
            }
            else
            {
                deathAnimationStart = false;
                timer = 0;
                if(life == 0)
                {
                    Debug.Log("game Over !");
                }

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            
        }
    }







    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Tonneau"))
        {
            if(!isHammerTaken)
            {
                Debug.Log(life);
                life -= 1;
                deathAnimationStart = true;
            }
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Marteau"))
        {
            isHammerTaken = true;
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Echelle"))
        {
            if (!isHammerTaken)
            {
                if(canUp)
                {
                    canUp = false;
                }
                else
                {
                    canPressUp = true;
                }
            }
        }
        else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("NonEchelle"))
        {
            canPressUp = false;
            isTop = false;
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("BarriereGauche"))
        {
            barriereGauche = true;
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("BarriereDroite"))
        {
            barriereDroite = true;
        }
    }
}
