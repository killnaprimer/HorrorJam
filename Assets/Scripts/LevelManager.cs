using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Scenes/Level_AES");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
        
        
    }

    public void LoadEnding()
    {
        SceneManager.LoadScene("EndingScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
