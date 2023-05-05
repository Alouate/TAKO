using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPosition : MonoBehaviour
{
    public float speed = 5f; // la vitesse de d�placement
    public KeyCode Right = KeyCode.Mouse0; // la touche d'input pour d�clencher le d�placement
    

    private void Update()
    {
        // si l'input est d�tect�
        if (Input.GetKeyDown(Right))
        {
            // d�placer l'objet vers la droite
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
    }
}