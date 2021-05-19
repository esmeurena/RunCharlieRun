using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheckpointPositionScript : MonoBehaviour
{
    private GameMasterScript GMS;

    // Start is called before the first frame update
    void Start()
    {
        GMS = GameObject.Find("Game Master").GetComponent<GameMasterScript>();
        transform.position = GMS.LastPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "KillMe")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }    
    }
}
