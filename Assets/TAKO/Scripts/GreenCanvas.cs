using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenCanvas : MonoBehaviour
{
    public Canvas CanvasGreen; // le canvas à afficher

    private void Start()
    {
        // cacher le canvas au démarrage du jeu
        CanvasGreen.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // si l'objet entre en collision avec un autre objet
        if (collision.gameObject.tag == "Obstacle")
        {
            // afficher le canvas
            CanvasGreen.enabled = true;
        }
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myCanvas.enabled = !myCanvas.enabled;
        }
    }*/
}
