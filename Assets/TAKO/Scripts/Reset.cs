using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    //Update is called once per frame
   /* void Update()
    {
        
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collisionbbbb");
        if (collision.gameObject.tag == "Obstacle")
        {

          //  StartCoroutine(ChangeSceneWithDelay("TAKO/TAKORDU", 6.0f));
            Debug.Log("compte à rebours");
            Invoke("reloadScene", 6f);
        }
       
    }

  

    public void reloadScene()
    {
        SceneManager.LoadScene("TAKO/TAKORDU");

    }


}

