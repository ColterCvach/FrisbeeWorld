using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAffectedPlayer : GravityAffected {

    public float moveSpeed = 0.1f;
    public float rotationSpeed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        GravityUpdate();
        HandleRotation(); 
        HandleInput();
        ChangeOrientation();
    }


    public void HandleRotation()
    {
        Vector3 planetNormal = (this.gameObject.transform.position - StrongestSource.gameObject.transform.position).normalized;
        float dotResult = Vector3.Dot(Camera.main.transform.forward, planetNormal);
        this.transform.forward = (Camera.main.transform.forward - (planetNormal * dotResult)); 
    }


    private void HandleInput()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
        this.transform.position += (this.transform.forward * verticalMovement) * moveSpeed * Time.deltaTime;
        this.transform.Rotate(this.transform.up, horizontalMovement *  rotationSpeed * Time.deltaTime);
    }
}
