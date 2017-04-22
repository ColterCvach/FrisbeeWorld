using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityAffected : MonoBehaviour
{
    public GravitySource source;
    public bool grounded;
    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        source.Pull(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 10 && grounded)
        {
            grounded = false;
        }
    }
}