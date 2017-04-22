using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySource : MonoBehaviour {
    public float GravityAcceleration = -10.0f;
    public float GravityFadeStart;
    public float GravityFadeEnd;
    public bool GravityProportionateToScale = true;
    private float radiousProportion = 0.75f;
    private float radiousFadeProportion = 1.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        if (GravityProportionateToScale)
        {
            GravityFadeStart = transform.localScale.x * radiousProportion;
            GravityFadeEnd = transform.localScale.x * radiousFadeProportion;
        }

        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere(transform.position, GravityFadeStart);
        Gizmos.DrawWireSphere(transform.position, GravityFadeEnd);

    }

    public Vector3 Pull(GravityAffected body)
    {
        Vector3 gravityUp;

        Transform trans = body.transform;
        Rigidbody rigidBody = body.GetComponent<Rigidbody>();
        float distanceToSource = Vector3.Distance(trans.position, this.transform.position);
        gravityUp = trans.position - transform.position;
        gravityUp.Normalize();

        Vector3 forceVector = new Vector3();
        if(distanceToSource < GravityFadeStart)
        {
            forceVector = gravityUp * GravityAcceleration * rigidBody.mass;
         }
        else if (distanceToSource > GravityFadeStart && distanceToSource < GravityFadeEnd)
        {
            forceVector = gravityUp * (GravityAcceleration * (1 - (distanceToSource - GravityFadeStart) / (GravityFadeEnd - GravityFadeStart))) * rigidBody.mass;
        }
        rigidBody.AddForce(forceVector);
        rigidBody.drag = (body.Grounded) ? 1 : 0.1f;
        return forceVector;
    }
}
