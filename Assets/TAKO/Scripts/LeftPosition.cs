using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPosition : MonoBehaviour
{
    public float speed = 5f; // la vitesse de d�placement
    public KeyCode Left = KeyCode.Mouse1; // la touche d'input pour d�clencher le d�placement

    private void Update()
    {
        // si l'input est d�tect�
        if (Input.GetKeyDown(Left))
        {
            // d�placer l'objet vers la droite
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}