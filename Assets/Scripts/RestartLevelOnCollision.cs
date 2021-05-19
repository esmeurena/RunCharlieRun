using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //new library, adding packages of scripts

public class RestartLevelOnCollision : MonoBehaviour
{    
    //used to prevent other objects(non-player) from activating restart when touching plane
    [SerializeField]
    string strTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == strTag)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            //needs .name for it to be an acceptable function; can't just use SceneManager 
    } 

}
