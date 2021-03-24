using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerDetection : MonoBehaviour
// Remember to give this script to all fingertips
{
	// delaying outputs (so not activating every frame)
	// https://forum.unity.com/threads/how-to-add-delay-on-button-press.540609/
	float lastTime;
	float delay = 0.5f;
	// ^^ those should not be for fingers, only for keys (?)^^
	
	
	
    // Start is called before the first frame update
    void Start()
    {

    }

	public void DebugThis(int direction)
	{	
		// a function to test stuff, not to be used in final demo
	
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
		
		// lets try turning it on and off too...
		//int direction = 1;
		// get dir from call instead
		
		dtg.GetComponent<Output>().Vibrate(this.name, direction);
	}

	public void OnTriggerEnter(Collider other)
	{
	// as this is given to a GameObject, there is "this"
	// and colliding with the other object
		Debug.Log(this.name + " touched/touches " + other.name);
		
		// get DataToGlove object
		GameObject dtg = GameObject.Find("DataToGlove");
		
		// direction is ON
		int direction = 1; 
		dtg.GetComponent<Output>().Vibrate(this.name, direction );
	}
	
	public void OnTriggerExit(Collider other)
	{
		Debug.Log(this.name + " no longer touches " + other.name);
		
		// get DataToGlove object
		GameObject dtg = GameObject.Find("DataToGlove");
		
		// direction is OFF
		int direction = 0; 
		dtg.GetComponent<Output>().Vibrate(this.name, direction);
	}
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
