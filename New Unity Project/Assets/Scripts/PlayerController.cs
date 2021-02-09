using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Player Controller - Permet de gérer le controle du personnage
 * - Mouvement sur un plan
 * - Creation d'attaque 
 */
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
   
    public Transform view;

    [Header("MOUVEMENT")]

    [Range(0, 10000)]
    public float speed = 1;

    



    private Rigidbody rigidBodyPlayer;

    public int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
       
        rigidBodyPlayer = GetComponent<Rigidbody>();


    }

    void Update()
    {
        // Appel de la fonction d'update du mouvement
        UpdateMove();

       
    }

    private void UpdateMove()
    {
        // Vecteur pour la direction du mouvement
        Vector3 moveDir = Vector3.zero;

        // On recupère les inputs droite/gauche et on applique sur l'axe Z
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDir.x = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir.x = -1;
        }

        // On recupère les inputs haut/bas et on applique sur l'axe X
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDir.y = -1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDir.y = 1;
        }

        // Permet de forcer la magnitude du vecteur à 1.
        // Magnitude : longeur du vecteur
        moveDir.Normalize();

        // On (force) applique la velocité du rigidbody
        // calculée à partir de la speed et du vecteur direction. 
        rigidBodyPlayer.velocity = moveDir * speed;

        // On test si le vecteur direction est different de (0,0,0) : Vecteur zero
        if (moveDir != Vector3.zero)
        {
            // Si oui
            // On force la rotation du player pour qu'il regarde dans la direction
            // du vecteur de mouvement.
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
    }

    /*
     * Methode générique de creation d'attaque
     * - Copie du GameObject passé en paramètre
     * - Placement dans l'espace à partir de la ref Orgine Attack
     * - Initialisation si l'object copié est une bullet
     */
  
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
           
        }
    }
}
