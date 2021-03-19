using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public GameObject timer;
    private Timer _timerScript;
    // Start is called before the first frame update
    void Start()
    {
        _timerScript = timer.GetComponent<Timer>();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "Player")
        {
            _timerScript.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
