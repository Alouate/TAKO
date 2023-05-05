using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCanvas : MonoBehaviour
{
    public Canvas CanvasRed; // le canvas à afficher

    private void Start()
    {
        // cacher le canvas au démarrage du jeu
        CanvasRed.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // si l'objet entre en collision avec un autre objet
        if (collision.gameObject.tag == "Obstacle")
        {
            // afficher le canvas
            CanvasRed.enabled = true;
        }
    }
}
