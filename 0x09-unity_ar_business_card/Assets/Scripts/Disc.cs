using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc : MonoBehaviour
{
    public AudioClip ts;
    AudioSource audioSourse;

    // Start is called before the first frame update
    void Start()
    {
        audioSourse = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDiscord()
    {
        StartCoroutine(doShit()); 
    }

    IEnumerator doShit()
    {
        audioSourse.PlayOneShot(ts, 1.0f);
        yield return new WaitForSeconds(3);
        Application.OpenURL("https://discord.gg/e9xWK7sNJj");
    }
}
