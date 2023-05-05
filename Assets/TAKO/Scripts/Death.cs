using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public AudioSource sourceW;
    public AudioSource sourceA;
    public AudioClip clipW;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        // si l'objet entre en collision avec un autre objet
        if (collision.gameObject.tag == "Obstacle")
        {

            // détruire l'objet
            sourceW.PlayOneShot(clipW);
            sourceA.Pause();

          //  Destroy(gameObject);
        }
    }
}
