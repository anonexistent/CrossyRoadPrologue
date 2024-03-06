using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool guipuse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            guipuse = true;
            Time.timeScale = 0;
        }
    }

    public void OnGUI()
    {
        if (guipuse == true)
        {
            Cursor.visible = true;

            //if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 150f, 150f, 45f), "continue")) 
            //{ 
            //    ispuse = false; 
            //    timer = 0; 
            //    Cursor.visible = false; 
            //} 
            //if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 100f, 150f, 45f), "restart"))
            //{
            //    ispuse = false;
            //    timer = 0;
            //    //Application.LoadLevel("level3TEST");
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //}
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 50f, 150f, 45f), "save as"))
            {
                Time.timeScale = 1;
                guipuse = false;
            }
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2), 150f, 45f), "main menu"))
            {
                Application.Quit();
            }
        }
    }
}
