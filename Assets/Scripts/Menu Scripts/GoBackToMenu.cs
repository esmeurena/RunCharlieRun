using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Application.LoadLevel is obsolete

public class GoBackToMenu : MonoBehaviour
{
    public GUISkin mySkin;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        if(GUI.Button(new Rect(20, 20, 100, 50), "Menu")) //original settings: Rect(20,20,200,100)
        {
            //Application.LoadLevel(0);
            SceneManager.LoadScene(0);
        }
    }

}   
