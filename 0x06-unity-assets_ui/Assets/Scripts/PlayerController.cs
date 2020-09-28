using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Vector3 jump;
    float jumpForce = 2.0f;
    bool isGrounded;
    bool forceReset = true;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.5f, 0.0f);
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
        if (transform.position.y < -8)
        {
            transform.position = new Vector3(0, 9.25f, 0);
        }
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.S))
            transform.position = transform.position + -Camera.main.transform.forward * 3.5f * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            transform.position = transform.position + Camera.main.transform.forward * 3.5f * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            transform.position = transform.position + -Camera.main.transform.right * 3.5f * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.position = transform.position + Camera.main.transform.right * 3.5f * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            forceReset = false;
            StartCoroutine(Jump());
        }
    }
}
