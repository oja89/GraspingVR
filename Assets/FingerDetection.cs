using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerDetection : MonoBehaviour
// Give this script to all fingertips
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public void OnTriggerEnter(Collider other)
	{
	// as this is given to a GameObject, there is "this"
	// and colliding with the other object
		Debug.Log(this.name + " touched/touches " + other.name);
	}
	
	public void OnTriggerExit(Collider other)
	{
		Debug.Log(this.name + " no longer touches " + other.name);
	}
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
