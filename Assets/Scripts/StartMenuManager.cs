using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    GameObject startMenu;
    private void Start()
    {
        startMenu = GameObject.Find("StartMenu");
    }
    private void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            startMenu.gameObject.SetActive(!startMenu.gameObject.activeSelf);
        }
    }

    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
