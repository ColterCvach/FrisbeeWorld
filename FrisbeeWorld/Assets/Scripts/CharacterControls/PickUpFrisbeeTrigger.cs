using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFrisbeeTrigger : MonoBehaviour {

    Player player;

    Throwable _currentThrowable;

    List<Throwable> _availableThrowables = new List<Throwable>(); 

    void Awake()
    {
        player = GetComponentInParent<Player>();
        player.attemptPickup += PickUpThrowable;
    }



    public void PickUpThrowable()
    {
        if(_availableThrowables.Count>0)
        {
            bool worked = player.PickUpThrowable(_availableThrowables[0]);
            if(worked)
            {
                _availableThrowables.Remove(_availableThrowables[0]); 
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Throwable t = other.GetComponent<Throwable>();
        if (t != null)
        {
            _availableThrowables.Add(t); 
        }
        //Destroy(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        Throwable t = other.GetComponent<Throwable>();
        if (t != null)
        {
            _availableThrowables.Remove(t);
        }
    }
}
