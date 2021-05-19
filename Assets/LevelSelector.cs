using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //need when Application.LoadLevel is obsolete

public class LevelSelector : MonoBehaviour
{
    public int buttonWidth;
    public int buttonHeight;
    private int origin_x;
    private int origin_y;
    public GUISkin mySkin;

    // Start is called before the first frame update
    void Start()
    {
        buttonWidth = 150; //original settings: 200
        buttonHeight = 50; //original settings: 50
        origin_x = Screen.width / 2 - buttonWidth / 2;
        origin_y = Screen.height / 2 - buttonHeight * 2;
    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        if (GUI.Button(new Rect(origin_x - buttonWidth - 20, origin_y + 20, buttonWidth, buttonHeight), "Level 1"))
        {
            //Load level 1   
            SceneManager.LoadScene(2);
        }
       
        if(GUI.Button(new Rect(origin_x, origin_y + 20, buttonWidth, buttonHeight), "Level 2"))
        {
            //Load level 2   
            SceneManager.LoadScene(3);
        }   
        

        if(GUI.Button(new Rect(origin_x + buttonWidth + 20, origin_y + 20, buttonWidth, buttonHeight), "Level 3"))
        {
            //Load level 3
            Application.LoadLevel(4);    
        }

        //Add another button to quit the game
        if (GUI.Button(new Rect(origin_x - buttonWidth * 3 + 10, origin_y - buttonHeight * 2 - 30, buttonWidth, buttonHeight), "Back"))
        {
            //Load level 1   
            SceneManager.LoadScene(0);
        }

    }
}
