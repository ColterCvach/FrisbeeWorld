using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    [SerializeField] private float _lifeTime = 2f;


	// Use this for initialization
	void Start () {
		
	}

    void OnEnable()
    {
        Destroy(this.gameObject, _lifeTime); 
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
