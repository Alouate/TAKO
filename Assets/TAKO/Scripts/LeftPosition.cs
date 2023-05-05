using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPosition : MonoBehaviour
{
    public float speed = 5f; // la vitesse de déplacement
    public KeyCode Left = KeyCode.Mouse1; // la touche d'input pour déclencher le déplacement

    private void Update()
    {
        // si l'input est détecté
        if (Input.GetKeyDown(Left))
        {
            // déplacer l'objet vers la droite
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}