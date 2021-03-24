using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerDetection : MonoBehaviour
// Give this script to all fingertips
{
	// delaying outputs (so not activating every frame)
	// https://forum.unity.com/threads/how-to-add-delay-on-button-press.540609/
	float lastTime;
	float delay = 0.5f;
	
    // Start is called before the first frame update
    void Start()
    {

    }

	public void DebugThis()
	{	
		// prints many rows, lets try to reduce activations
		if (lastTime + delay > Time.unscaledTime)
			return;
		lastTime = Time.unscaledTime;
				
		// test connection to another object
		string thisName = this.name;
		//Debug.Log(thisName);
		
		//get object of GlobalScripts
		//GameObject gs = GameObject.Find("GlobalScripts");
		//gs.GetComponent<DebugWrite>().AnotherTest(thisName);
		
		
		// get DataToGlove object
		GameObject dtg = GameObject.Find("DataToGlove");
		dtg.GetComponent<Output>().Vibrate(this.name);
	
		
	}

	public void OnTriggerEnter(Collider other)
	{
	// as this is given to a GameObject, there is "this"
	// and colliding with the other object
		Debug.Log(this.name + " touched/touches " + other.name);
		
		// get DataToGlove object
		GameObject dtg = GameObject.Find("DataToGlove");
		dtg.GetComponent<Output>().Vibrate(this.name);
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
