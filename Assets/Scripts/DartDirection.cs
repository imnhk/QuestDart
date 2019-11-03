using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartDirection : MonoBehaviour
{
    public GameObject gameManagerObj;

    private GameManager gameManager;
    private Rigidbody rb;
    private OVRGrabbable grabbable;
    private Collider col;
    private ParticleSystem particle;

    private bool isStuck = false;

    // Start is called before the first frame update
    void Start()
    {
    
        gameManager = gameManagerObj.GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        grabbable = GetComponent<OVRGrabbable>();
        col = GetComponent<Collider>();
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 1f && !grabbable.isGrabbed)
        {
            this.transform.rotation = Quaternion.LookRotation(new Vector3(-rb.velocity.z, rb.velocity.y, rb.velocity.x), transform.up);
            isStuck = false;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Board" && !isStuck)
        {
            isStuck = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.useGravity = false;

            particle.Play();

            float dist = Vector3.Distance(transform.position, gameManager.center.transform.position);
            gameManager.score += (int)Mathf.Clamp(10 - dist * 10, 0f, 10f);
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Board")
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
        }

    }
}
