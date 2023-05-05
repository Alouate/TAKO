using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySocketIO;
using UnitySocketIO.Events;

public class ControlImputOverWS : MonoBehaviour
{

    SocketIOController io;

   // Rigidbody rgbd;
    public float speed = 200f; // la vitesse de déplacement
    public int score = 0;
    private int previousScore = 0;

    /*public float power = 6;
    public Transform directionMarker;
    public float directionMarkerInitLength = 0.1f;
    public float directionMarkerMaxLength = 2;
    public float directionMarkerGrowSpeed = 0.1f;
    public float directionMarkerCurrentLength;
    public float inactifDelay = 10;
    public bool isActif = true;
    private float timer = 0;
    private Vector3 direction;
    private Vector3 initialSize;
    public int score = 0;
    public int scoreIncr = 1;
    public float scoreTickDelay = 2;
    public float scoreTickTimer = 0;
    public GameObject scoreDisplay;*/

    private System.Action<SocketIOEvent> tire,input2Action;

    // Start is called before the first frame update
    void Start()
    {
        /*initialSize = transform.localScale;
        directionMarkerCurrentLength = directionMarkerInitLength;
        rgbd = GetComponent<Rigidbody>();*/

        io = SocketIOController.instance;

        tire = (SocketIOEvent e) => {

            if (e.data == gameObject.name)
            {
                /*// si l'input est détecté
                if (Input.GetKeyDown(Right))*/

                // Vérifier si le score a été augmenté de 1
                if (score - previousScore == 1)
                {
                        Debug.Log("Score a augmenté de 1 !");
                        previousScore = score;
                    // déplacer l'objet vers la droite
                    transform.position += Vector3.right * speed * Time.deltaTime;
                }

                /* // si l'input est détecté
                if (Input.GetKeyDown(Left))*/

                // Vérifier si le score a été diminué de 1
                if (score - previousScore == -1)
                {
                    Debug.Log("Score a diminué de 1 !");
                    previousScore = score;
                    // déplacer l'objet vers la droite
                    transform.position += Vector3.left * speed * Time.deltaTime;
                }

                /*Debug.Log("UP");
                if (directionMarker)
                {
                    direction = directionMarker.position - transform.position;
                }
                else
                {
                    direction = Vector3.up;
                }
                rgbd.AddForce(direction * power, ForceMode.Impulse);
                isActif = true;
                timer = 0;*/
            }

        };

        /*input2Action = (SocketIOEvent e) => {
            if (e.data == gameObject.name)
            {
               

                if (directionMarker)
                {
                    directionMarker.GetComponent<TurnAround>().rotationSpeed *= -1;
                    isActif = true;
                    timer = 0;
                }
            }
        };*/

        io.On("input1", tire);

        //io.On("input2",input2Action);
    }

    // Update is called once per frame
    void Update()
    {
        /*timer += Time.deltaTime;
        if (timer > inactifDelay)
        {
            isActif = false;
        }

        if (isActif)
        {
            resetLength();
        }
        else
        {
            growUp();
        }

        scoreTickTimer += Time.deltaTime;
        if (scoreTickTimer > scoreTickDelay)
        {
            updateScore();
            scoreTickTimer = 0;
        }*/
    }

    /*private void updateScore()
    {
        score += scoreIncr;
        if(scoreDisplay)
        scoreDisplay.GetComponent<ScoreData>().updateDisplay(score);
    }
    
    private void growUp()
    {
        if (directionMarkerCurrentLength < directionMarkerMaxLength)
        {
            directionMarkerCurrentLength += directionMarkerGrowSpeed * Time.deltaTime;    
        }
        directionMarker.localScale = new Vector3(directionMarkerCurrentLength,initialSize.y,initialSize.z);

    }

    private void resetLength()
    {
        directionMarkerCurrentLength = directionMarkerInitLength;
        directionMarker.localScale = new Vector3(directionMarkerCurrentLength,initialSize.y,initialSize.z);
    }*/

    private void OnDestroy()
    {
        io.Off("input1", tire);
        /*io.Off("input2", input2Action);*/
       // Destroy(scoreDisplay);
        //GameManager.instance.scoreList.Remove(scoreDisplay.GetComponent<ScoreData>());

    }
}
