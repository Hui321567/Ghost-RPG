using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle : MonoBehaviour
{   
   
    public GameObject Player;
    bool isPlayerInRange;
    public GameEndTrigger GameEndTrigger;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            GameEndTrigger.CaughtPlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            isPlayerInRange = true;
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            isPlayerInRange = false;
        }
    }
}
