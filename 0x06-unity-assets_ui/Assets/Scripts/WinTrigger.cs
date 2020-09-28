using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject timer;
    private Timer _timerScript;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        _timerScript = timer.GetComponent<Timer>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (_timerScript.enabled)
        {
            if (other.transform.name == "Player")
            {
                Debug.Log("Victory");
                _timerScript.enabled = false;
                _timerScript.StopRepp();
                timerText.fontSize = 80;
                timerText.color = Color.green;
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
