using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySocketIO;
using UnitySocketIO.Events;

class PlayerData
{
    public string id;
    public string teamID;
    public bool scores;
}

public class RopeGameManager: MonoBehaviour
{

    public static RopeGameManager instance;
    public GameObject objectToSpawn;
    public List<GameObject> spawnedObjects;
    public float ropePosition = 0;
    public GameObject rope;
    public GameObject RedPoulpe, BluePoulpe;

    SocketIOController io;
    public int[] teamCount = { 0, 0 };

    //public static int RedSpawnPoint;
    //public static int BlueSpawnPoint;

    public AudioSource sourceS;
    public AudioClip clipS;

    // Start is called before the first frame update

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        io = SocketIOController.instance;
        io.On("connect", (SocketIOEvent e) =>
        {
            Debug.Log("SocketIO connected");
        });

        io.Connect();


        io.On("spawn", (SocketIOEvent e) =>
        {
            // Lorsqu'on recoit un message "spawn".
            // On verifie qu'il n'existe pas déjà un joueur du même nom.
            PlayerData pData = (PlayerData)JsonUtility.FromJson(e.data, typeof(PlayerData));
            Debug.Log(e.data);
            if (RopeGameManager.instance.spawnedObjects.Find(x => x.name == pData.id) == null)
            {

                //Si on ne trouve pas son nom dans la liste des joueurs instanciés,
                //C'est un nouveau joueur, On doit donc l'instancier.

                Debug.Log(e.data); // on affiche dans la console le pseudo joueur

                Debug.Log(pData.id + " - " +pData.teamID);

                //?????????
                Vector3 blueSpawnPoint = new Vector3(Random.Range(-14, -27), Random.Range(-1, -4), -1);
                Vector3 redSpawnPoint = new Vector3(Random.Range(27, 14), Random.Range(-1, -4), -1);

                Vector3 spawnPoint = (pData.teamID == "0") ? redSpawnPoint : blueSpawnPoint;

                GameObject tmp = Instantiate(objectToSpawn, spawnPoint, Quaternion.identity);

                // On renome l'objet avec le pseudo du joueur.
                tmp.name = pData.id;

                if(pData.teamID == "0")
                {
                    tmp.GetComponent<RopePlayer>().teamID = 0;
                    teamCount[0]++;

                }
                else if (pData.teamID == "1")
                {

                    tmp.GetComponent<RopePlayer>().teamID = 1;
                    teamCount[1]++;
                }
                
                /* else if (pData.teamID == "-1")
                 {

                     if (teamCount[0] < teamCount[1])
                     {
                         tmp.GetComponent<RopePlayer>().teamID = 0;
                         teamCount[0]++;

                     }
                     else if (teamCount[0] > teamCount[1])
                     {

                         tmp.GetComponent<RopePlayer>().teamID = 1;
                         teamCount[1]++;

                     }
                     else if (teamCount[0] > teamCount[1])
                     {

                         int nbr = Random.Range(0, 100);
                         tmp.GetComponent<RopePlayer>().teamID = (nbr >= 20 ?1:0);
                         teamCount[tmp.GetComponent<RopePlayer>().teamID]++;

                     }
                 }*/

                // On ajouter le joueur à la liste des joueurs instanciés.
                RopeGameManager.instance.spawnedObjects.Add(tmp);

            }
            else// Si le joueur est déjà dans la liste, on ne l'instancie pas à nouveau.
            {
                Debug.Log("User" + e.data + " already exist");
            }
            sourceS.PlayOneShot(clipS);
        });

    }

    // Update is called once per frame
    void Update()
    {
        rope.transform.position = new Vector3(ropePosition, rope.transform.position.y, rope.transform.position.z);
    }
}
