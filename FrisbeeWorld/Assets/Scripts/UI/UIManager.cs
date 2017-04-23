using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {



    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }


    [SerializeField] private GameObject _pickUpFrisbeeObject;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void DisplayPickUpFrisbeeText()
    {
        _pickUpFrisbeeObject.SetActive(true);
    }

    public void HidePickupFrisbeeText()
    {
        _pickUpFrisbeeObject.SetActive(false);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
