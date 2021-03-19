using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject player;
    PlayerController pcScript;
    CameraController ccScript;
    Timer tScript;
    public GameObject pauseMenu;
    Vector3 pos;
    public Button resumeButt, reloadButt, mmButt, opButt;
    bool pasued = false;
    // Start is called before the first frame update
    void Start()
    {
        pcScript = player.GetComponent<PlayerController>();
        tScript = player.GetComponent<Timer>();
        ccScript = GetComponent<CameraController>();
        resumeButt.onClick.AddListener(Resume);
        reloadButt.onClick.AddListener(Restart);
        mmButt.onClick.AddListener(MainMenu);
        opButt.onClick.AddListener(Options);
    }

    // Update is called once per frame
    void Update()
    {
        if(pasued)
        {
            player.transform.position = pos;
            pcScript.enabled = false;
            ccScript.enabled = false;
        }
        

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("test");
            if(pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pos = player.transform.position;
        pasued = true;
        tScript.StopRepp();
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        pasued = false;
        tScript.StartRepp();
        pcScript.enabled = true;
        ccScript.enabled = true;
    }
    public void Options()
    {
        PlayerPrefs.SetString ("lastLoadedScene", SceneManager.GetActiveScene ().name);
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        PlayerPrefs.SetString ("lastLoadedScene", SceneManager.GetActiveScene ().name);
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
