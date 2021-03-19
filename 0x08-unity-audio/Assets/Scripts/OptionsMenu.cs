using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Button backButt, applyButt;
    public Toggle inverYTogg;
    // Start is called before the first frame update
    void Start()
    {
        backButt.onClick.AddListener(Back);
        applyButt.onClick.AddListener(Apply);
        int isInverInt = PlayerPrefs.GetInt("isInvert", 0);
        if(isInverInt == 1)
        {
            inverYTogg.isOn = true;
        }
        else
        {
            inverYTogg.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(sceneName);
    }

    public void Apply()
    {
        Debug.Log("test");
        if (inverYTogg.isOn)
        {
            string sceneName = PlayerPrefs.GetString("lastLoadedScene");
            PlayerPrefs.SetInt("isInvert", 1);
            SceneManager.LoadScene(sceneName);
            Debug.Log("test2");
        }
        else
        {
            string sceneName = PlayerPrefs.GetString("lastLoadedScene");
            PlayerPrefs.SetInt("isInvert", 0);
            SceneManager.LoadScene(sceneName);
            Debug.Log("test2");
        }
    }
}
