using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerTipFinder : MonoBehaviour
{
	
	// list of objects to track
	//public int[] fingertips;
	public GameObject[] fingertips;
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	
	public void OnTriggerEnter(Collider	c)
	{
		var coll = c.name;
		Debug.Log("Collision " + coll);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
