using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        sounds = GameObject.FindGameObjectsWithTag("Sound");
        for (int i = 1; i < sounds.Length; i++)
        {
            Destroy(sounds[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        SceneManager.LoadScene("Game");
        DontDestroyOnLoad(sounds[0]);

    }

    public void back()
    {
        SceneManager.LoadScene("SampleScene");

    }

    public void exit()
    {
        Application.Quit();
    }
}
