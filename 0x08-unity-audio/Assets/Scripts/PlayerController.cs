using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public AudioSource death;
    public AudioSource birds;
    public GameObject tree;
    Vector3 jump;
    float jumpForce = 2.0f;
    bool isGrounded;
    bool forceReset = true;
    Rigidbody rb;
    AudioSource runningGrass;

    Vector2 distance;

    float currentX;
    float currentZ;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentX = transform.position.x;
        currentZ = transform.position.z;
        runningGrass = GetComponent<AudioSource>();
        jump = new Vector3(0.0f, 3.5f, 0.0f);

        InvokeRepeating("CheckMovment", 0.3f, 0.1f);
    }


    IEnumerator Jump()
    {
        if (isGrounded)
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                yield return new WaitForSeconds(0.1f);
                isGrounded = false;
                forceReset = true;
            }
    }
    void OnCollisionStay()
    {
        isGrounded = true;
        if (forceReset)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.angularVelocity = new Vector3(0, rb.angularVelocity.y, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float treeDistance = Vector3.Distance(transform.position, tree.transform.position);
        Debug.Log(Vector3.Distance(transform.position, tree.transform.position));
        if ((treeDistance <= 10) && (!birds.isPlaying))
            birds.Play();
        else if((treeDistance > 10) && (birds.isPlaying))
            birds.Stop();
        if (transform.position.y < -8)
        {
            transform.position = new Vector3(0, 9.25f, 0);
            death.Play();
        }
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + -Camera.main.transform.forward * 3.5f * Time.deltaTime;
        }    
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + Camera.main.transform.forward * 3.5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + -Camera.main.transform.right * 3.5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + Camera.main.transform.right * 3.5f * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            forceReset = false;
            StartCoroutine(Jump());
        }
        if (!isGrounded)
            runningGrass.Stop();
    }

    void CheckMovment()
    {
        Vector2 old = new Vector2(currentX, currentZ);
        Vector2 realCurrent = new Vector2(transform.position.x, transform.position.z);
        float distance = Vector2.Distance(old, realCurrent);

        if (distance > 0.3)
        {
            currentX = transform.position.x;
            currentZ = transform.position.z;
            if (!runningGrass.isPlaying)
            {
                runningGrass.Play();
            }
        }
        else
            runningGrass.Stop();
    }
}
