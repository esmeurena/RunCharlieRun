using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaseScript : MonoBehaviour
{
    public GameObject Player;
    public float ChaseSpeed;
    public bool PlayerFound = false;

    public float xOffset;
    public float yOffset;
    public float zOffset;

    private GameMasterScript GMS;

    void Start()
    {
        GMS = GameObject.Find("Game Master").GetComponent<GameMasterScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Player.transform.position);
        if (PlayerFound)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.transform.position.x + xOffset, Player.transform.position.y + yOffset, Player.transform.position.z + zOffset), ChaseSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            if(PlayerFound)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
