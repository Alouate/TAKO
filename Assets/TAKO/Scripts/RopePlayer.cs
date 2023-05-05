using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySocketIO;
using UnitySocketIO.Events;

/*class PlayerData
{
    public string id;
    public string teamID;
    public bool points;

}*/

public class RopePlayer : MonoBehaviour
{
    public Animator animator;
    public static RopeGameManager ropeGameInstance;
    public int teamID = 0;
    public Material mat1, mat2;

    SocketIOController io;

    private System.Action<SocketIOEvent> input1Action;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        ropeGameInstance = RopeGameManager.instance;
        io = SocketIOController.instance;

        if (teamID == 0)
        {
            anim = ropeGameInstance.RedPoulpe.GetComponent<Animator>();
        }
        else
        {
            anim = ropeGameInstance.BluePoulpe.GetComponent<Animator>();
        }
       

        GetComponent<Renderer>().material = (teamID == 0) ? mat1 : mat2;

       
        input1Action = (SocketIOEvent e) =>
        {
            PlayerData pData = (PlayerData)JsonUtility.FromJson(e.data, typeof(PlayerData));
            
            if (pData.id == gameObject.name)
            {
                Debug.Log(teamID + " tire !! ");
                if (teamID == 0)
                {
                    anim.SetTrigger("RedPull");
                    ropeGameInstance.ropePosition += 1f;
 
                }
                else if (teamID == 1)
                {
                    anim.SetTrigger("BluePull");
                    ropeGameInstance.ropePosition -= 1f;

                }
            }
            

        };

        io.On("points", input1Action);

    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
