using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    private static TargetManager _instance;

    public static TargetManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if(_instance==null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject); 
        }
    }

    
    private List<BreakableTarget> _allTargets = new List<BreakableTarget>();

    [SerializeField] private List<BreakableTarget> _currentActiveTargetsForWold = new List<BreakableTarget>();
    public bool TargetSetComplete { get { return _currentActiveTargetsForWold.Count == 0; } }

    public void RegisterTarget(BreakableTarget t)
    {
        if(!_allTargets.Contains(t))
        {
            _allTargets.Add(t);
            t.onBrokenEvent += TargetBroken;

            // TODO: CREATE GAME MANAGER THAT HANDLES WHAT STAGE WE ARE ON
            if(t.TargetStageID!=1)
            {
                t.gameObject.SetActive(false); 
            }
            else
            {
                _currentActiveTargetsForWold.Add(t); 
            }
        }
    }

    private void TargetBroken(BreakableTarget t)
    {
        _currentActiveTargetsForWold.Remove(t); 
    }

    public void CreateWorldSetOfTargets(int worldID)
    {
        // TODO:fix this
    }
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
