using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour
{
	// Maybe an array for finger vibration statuses?
	// lets change the text on wall too
	string textArray = "Emptytext";

	// dictionary?
	Dictionary<string, int> fingers = new Dictionary<string, int>()
	{
		{"R_thumb_end", 0},
		{"R_index_end", 0},
		{"R_middle_end", 0},		
		{"R_ring_end", 0},
		{"R_pinky_end", 0},		
		{"L_thumb_end", 0},
		{"L_index_end", 0},		
		{"L_middle_end", 0},
		{"L_ring_end", 0},
		{"L_pinky_end", 0}
	};
	
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		textArray = "";
		foreach(KeyValuePair <string, int> key in fingers)
			{
				textArray += key.Key + " " + key.Value + "\n";
			};
		
		
		//textArray.concat+ = "R1: " + fingers["R1"] + "\n" +
				//	 "L1: " + fingers["L1"] + "\n" +
					//	"L2: " + fingers["L2"];
		
		
		
        // updating every frame, not the best idea...
		GameObject infoTxt = GameObject.Find("Text");
		infoTxt.GetComponent<UnityEngine.UI.Text>().text = textArray;
		
		
    }
	
	public void Vibrate(string caller, int direction)
	{
		Debug.Log("Please vibrate " + caller);
		
		//if (caller == "L_index_end")
			//Debug.Log("it was L-index");		
		
		string theFinger = "";
		
		theFinger = caller;
		
		// switch case detection for finger
		// (hardcoded for now at least)
		/* switch (caller)
		{
			case "L_thumb_end":
				Debug.Log("L1");
				fingers["L1"] = direction;
				break;
			case "L_index_end":

				theFinger = "L2";
				break;
			case "L_middle_end":
				Debug.Log("L3");
				break;
			case "L_ring_end":
				Debug.Log("L4");
				break;
			case "L_pinky_end":
				Debug.Log("L5");
				break;
			case "R_thumb_end":
				Debug.Log("R1");
				break;
			case "R_index_end":
				Debug.Log("R2");
				break;
			case "R_middle_end":
				Debug.Log("R3");
				break;
			case "R_ring_end":
				Debug.Log("R4");
				break;
			case "R_pinky_end":
				Debug.Log("R5");
				break;		
		} */
		
		// Apply the change and log it
		Debug.Log(theFinger);
		fingers[theFinger] = direction;
	}
}
