using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour
{
	// the text on wall, fill with dictionary
	string textArray = "Emptytext";

	// dictionary for finger vibration statuses
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

        // updating every frame, maybe not the best idea...
		GameObject infoTxt = GameObject.Find("Text");
		infoTxt.GetComponent<UnityEngine.UI.Text>().text = textArray;
		
		// should this call arduino now, with the values for each finger?
		// or vibrate() ?
		
    }
	
	public void Vibrate(string caller, int direction)
	{
		// change value in the dictionary
		fingers[caller] = direction;
		if (direction == 1) { 
			Debug.Log("Please vibrate " + caller);
		}
		else Debug.Log("Stop vibrating " + caller);
		
		
		// call for change in arduino?
		
	}
}
