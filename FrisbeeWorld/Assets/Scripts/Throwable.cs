using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour {

    [SerializeField] private float moveSpeed = 10f;
    GravityAffected _gravity; 
    

	// Use this for initialization
	void Start () {
        _gravity = GetComponent<GravityAffected>(); 
	}

    public void SetParentedTransform(Transform throwableParentedTransform)
    {
        this.transform.position = throwableParentedTransform.position;
        this.transform.rotation = throwableParentedTransform.rotation;
        this.transform.SetParent(throwableParentedTransform);
        DisableGravity(); 
    }

    public void DisableGravity()
    {
        _gravity.enabled = false; 
    }

    public void EnableGravity()
    {
        _gravity.enabled = true;

    }

    // Update is called once per frame
    void Update () {
		if(_gravity.enabled)
        {
            if(!_gravity.Grounded)
            {
                this.transform.position += (this.transform.forward) * moveSpeed * Time.deltaTime;
            }
        }
	}

    public void Throw()
    {
        this.transform.SetParent(null);
        EnableGravity(); 
    }
}
