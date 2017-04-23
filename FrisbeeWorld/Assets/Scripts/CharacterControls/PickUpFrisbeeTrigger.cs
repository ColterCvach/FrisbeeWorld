using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFrisbeeTrigger : MonoBehaviour {

    Player player;

    Throwable _currentThrowable;
    public event Action canPickupThrowable;
    public event Action outOfThrowables;
    public void OnCanPickupThrowable()
    {
        var handler = canPickupThrowable;
        if(handler !=null)
        {
            handler(); 
        }
    }

    public void OnOutOfThrowables()
    {
        var handler = outOfThrowables;
        if (handler != null)
        {
            handler();
        }
    }


    List<Throwable> _availableThrowables = new List<Throwable>();
    public bool CanPickupThrowable { get { return _availableThrowables.Count > 0; } }

    void Awake()
    {
        player = GetComponentInParent<Player>();
        player.attemptPickup += PickUpThrowable;
    }

    void Start()
    {
        canPickupThrowable += UIManager.Instance.DisplayPickUpFrisbeeText;
        outOfThrowables += UIManager.Instance.HidePickupFrisbeeText;
    }


    public void PickUpThrowable()
    {
        if(_availableThrowables.Count>0)
        {
            bool worked = player.PickUpThrowable(_availableThrowables[0]);
            if(worked)
            {
                _availableThrowables.Remove(_availableThrowables[0]);
                OnOutOfThrowables(); 
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Throwable t = other.GetComponent<Throwable>();
        if (t != null && player.CanEquipThrowable)
        {
            _availableThrowables.Add(t);
            OnCanPickupThrowable();
        }
        //Destroy(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        Throwable t = other.GetComponent<Throwable>();
        if (t != null)
        {
            _availableThrowables.Remove(t);
            if (_availableThrowables.Count == 0)
            {
                OnOutOfThrowables(); 
            }
        }
    }
}
