using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //need when Application.LoadLevel is obsolete


public class Menu : MonoBehaviour
{
    public int buttonWidth;
    public int buttonHeight;
    private int origin_x;
    private int origin_y;
    public GUISkin mySkin;

    // Start is called before the first frame update
    void Start()
    {
        buttonWidth = 200; //original settings: 200
        buttonHeight = 50; //original settings: 50
        origin_x = Screen.width / 2 - buttonWidth / 2;
        origin_y = Screen.height / 2 - buttonHeight * 2; 

    }
    //remove update function. Will not need it when making selection menu
    
    void OnGUI() 
    {
        GUI.skin = mySkin;
        if(GUI.Button(new Rect(origin_x, origin_y, buttonWidth, buttonHeight), "Game Scene 1"))
        {
            //load scene 1
            //Application.LoadLevel(1);    
            SceneManager.LoadScene(1);
        }   
        //add more for more scenes
        /*
        if(GUI.Button(new Rect(origin_x, origin_y + buttonHeight + 20, buttonWidth, buttonHeight), "Scene 2"))
        {
            //load scene 2
            //Application.LoadLevel(2);    
            SceneManager.LoadScene(2);
        }   
        */
        /*
        if(GUI.Button(new Rect(origin_x, origin_y + buttonHeight * 2 + 40, buttonWidth, buttonHeight), "Scene 3"))
        {
            //load scene 3
            Application.LoadLevel(3);    
        }   
        */
        //Add another button to quit the game
        if(GUI.Button(new Rect(origin_x, origin_y + buttonHeight * 3 + 60, buttonWidth, buttonHeight), "Quit"))
        {
            #if UNITY_EDITOR //check whether we're in debug mode
                UnityEditor.EditorApplication.isPlaying = false; //
            #else
                Application.Quit(); //if we're not in debug mode
                
            #endif
        }   
    }
}
