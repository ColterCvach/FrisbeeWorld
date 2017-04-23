using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableTarget : MonoBehaviour {

    [SerializeField] private GameObject _breakingVFX;
    [SerializeField] private int _targetStageId =1;


    public int TargetStageID { get { return _targetStageId; } }

    // add on break event
    public delegate void TargetBrokenDelegate(BreakableTarget t);
    public event TargetBrokenDelegate onBrokenEvent;
    

    public void OnTargetBroken()
    {
        var handler = onBrokenEvent;
        if(handler!=null)
        {
            handler(this); 
        }
    }


    void Awake()
    {
        TargetManager.Instance.RegisterTarget(this); 
    }


	// Use this for initialization
	void Start () {
		
	}

    void OnEnable()
    {
        // register onbreak with target manager

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag.Equals("Throwable"))
        {
            GameObject vfx = Instantiate(_breakingVFX);
            vfx.transform.position = this.gameObject.transform.position;
            vfx.gameObject.SetActive(true);
            
            // TODO: SET PARENT TO OWNING PLANET, JUST IN CASE PLANET IS MOVING WHEN BROKEN
            vfx.transform.parent = null;
            OnTargetBroken(); 
            this.gameObject.SetActive(false); 
            Destroy(this.gameObject, 0.5f);

        }
    }
}
