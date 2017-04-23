using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour {

    [SerializeField] private Transform _targetTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = _targetTransform.position;
	}
}
