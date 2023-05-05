using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPosition : MonoBehaviour
{
    public float speed = 5f; // la vitesse de déplacement
    public KeyCode Right = KeyCode.Mouse0; // la touche d'input pour déclencher le déplacement
    

    private void Update()
    {
        // si l'input est détecté
        if (Input.GetKeyDown(Right))
        {
            // déplacer l'objet vers la droite
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
    }
}