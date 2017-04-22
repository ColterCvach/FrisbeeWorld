using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityAffected : MonoBehaviour
{
    public GravitySource[] Sources;
    public GravitySource StrongestSource; 
    public bool Grounded;
    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
        StrongestSource = Sources[0];
    }

    // Update is called once per frame
    void Update()
    {
        GravityUpdate();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Grounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 10 && Grounded)
        {
            Grounded = false;
        }
    }

    private void GravityUpdate()
    {
        float strongestPull = 0.0f;
        for (int i = 0; i < Sources.Length; i++)
        {
            Vector3 pull = Sources[i].Pull(this);
            if(pull.magnitude > strongestPull)
            {
                StrongestSource = Sources[i];
                strongestPull = pull.magnitude;
            }
        }
        ChangeOrientation();
    }

    private void ChangeOrientation()
    {
        Vector3 localUp = this.transform.up;
        Vector3 gravityUp = this.transform.position - StrongestSource.transform.position;
        gravityUp.Normalize();
        Quaternion rotation = Quaternion.FromToRotation(localUp, gravityUp);
        rotation = rotation * this.transform.rotation;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, 0.1f);
    }
}