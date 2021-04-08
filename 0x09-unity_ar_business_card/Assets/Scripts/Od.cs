using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class Od : MonoBehaviour
{
    public Button dc;
    public Button li;
    public Button ig;
    public Button gh;
    public float seconds = 3;
    public float timer = 10;
    public Vector3 igP;
    public Vector3 dcP;
    public Vector3 ghP;
    public Vector3 liP;
    public Vector3 igDifference;
    public Vector3 dcDifference;
    public Vector3 ghDifference;
    public Vector3 liDifference;
    public Vector3 start = new Vector3(0, 0, 0);
    public float percent ;

    // Start is called before the first frame update
    void Start()
    {
        igP = new Vector3(8, -13.8f, 0);
        dcP = new Vector3(14, -1.7f, 0);
        ghP = new Vector3(-14, -1.7f, 0);
        liP = new Vector3(-8, -13.8f, 0);
        igDifference = igP - start;
        ghDifference = ghP - start;
        liDifference = liP - start;
        dcDifference = dcP - start;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= seconds) 
        {
            timer += Time.deltaTime;
            percent = timer / seconds;
            dc.transform.position = start + dcDifference * percent;
            ig.transform.position = start + igDifference * percent;
            li.transform.position = start + liDifference * percent;
            gh.transform.position = start + ghDifference * percent;
        }
    }

    void OnTargetFound()
    {
        dc.transform.position = new Vector3(0, 0, 0);
        li.transform.position = new Vector3(0, 0, 0);
        ig.transform.position = new Vector3(0, 0, 0);
        gh.transform.position = new Vector3(0, 0, 0);
        timer = 0;
    }
}
