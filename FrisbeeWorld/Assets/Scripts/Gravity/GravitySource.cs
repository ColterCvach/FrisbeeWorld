using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySource : MonoBehaviour {
    //why false?
    bool useLocalUP = false;

    float gravityAcceleration = -10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pull(GravityAffected body)
    {
        Vector3 gravityUp;
        Vector3 localUp;
        Vector3 localForward;

        Transform trans = body.transform;
        Rigidbody rigidBody = body.GetComponent<Rigidbody>();

        if (useLocalUP)
        {
            gravityUp = transform.up;
        } else
        {
            gravityUp = trans.position - transform.position;
            gravityUp.Normalize();
        }

        rigidBody.AddForce(gravityUp * gravityAcceleration * rigidBody.mass);
        rigidBody.drag = (body.grounded) ? 1 : 0.1f;

        if(rigidBody.freezeRotation)
        {
            localUp = trans.up;
            Quaternion rotation = Quaternion.FromToRotation(localUp, gravityUp);
            rotation = rotation * trans.rotation;
            trans.rotation = Quaternion.Slerp(trans.rotation, rotation, 0.1f);
            localForward = trans.forward;
        }
    }
}
