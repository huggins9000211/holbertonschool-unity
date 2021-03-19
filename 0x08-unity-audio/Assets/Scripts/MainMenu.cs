using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public Button lvl1, lvl2, lvl3, optionsButt, exitButt;
    // Start is called before the first frame update
    void Start()
    {
        lvl1.onClick.AddListener(delegate {LevelSelect(1); });
        lvl2.onClick.AddListener(delegate {LevelSelect(2); });
        lvl3.onClick.AddListener(delegate {LevelSelect(3); });
        optionsButt.onClick.AddListener(Options);
        exitButt.onClick.AddListener(MyExit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MyExit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
    public void Options()
    {
        PlayerPrefs.SetString ("lastLoadedScene", SceneManager.GetActiveScene ().name);
        SceneManager.LoadScene("Options");
    }
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene($"Level0{level}");
    }
}
