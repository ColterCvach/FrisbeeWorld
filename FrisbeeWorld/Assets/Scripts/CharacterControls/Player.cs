using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Throwable _throwable;
    [SerializeField] private Transform _throwableParentedTransform;

    public event Action attemptPickup;
    public void OnAttemptPickup()
    {
        var handler = attemptPickup;
        if(handler!=null)
        {
            handler(); 
        }
    }

    public bool CanEquipThrowable { get { return _throwable == null; } }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnAttemptPickup();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _throwable.Throw();
            _throwable = null; 
        }
    }


    public bool PickUpThrowable(Throwable t)
    {
        bool worked = false;
        if (CanEquipThrowable)
        {
            worked = true; 
            _throwable = t;
            _throwable.SetParentedTransform(_throwableParentedTransform);

        }
        return worked;
    }


}
