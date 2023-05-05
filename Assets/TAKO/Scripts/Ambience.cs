using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience : MonoBehaviour
{
    public AudioSource sourceA;
    public AudioClip clipA;
    

    // Start is called before the first frame update
    void Start()
    {
        sourceA.PlayOneShot(clipA);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        // si l'objet entre en collision avec un autre objet
        if (collision.gameObject.tag == "Obstacle")
        {

            // détruire l'objet
            sourceA.Pause();
            //  Destroy(gameObject);
        }
    }

    // Update is called once per frame


}
