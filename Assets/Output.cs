using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour
{
	// the text on wall, fill with dictionary
	string textArray = "Emptytext";

	// Serial port initialization for communicating with Arduino
	private static SerialPort sp = new SerialPort("COM3", 9600);

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
		OpenConnection();
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


		// Vibrates index finger
		if (caller == "L_index_end" && direction == 1)
		{
			// <thumb,index,middle>, values are vibration power
			// Do not exceed 150!!
			sp.Write("<0,100,0>");
		}
		// Stops vibrating index finger
		else if (caller == "L_index_end" && direction == 0)
		{
			sp.Write("<0,0,0>");
		}
	}

	// Opens connection to sp serial port
	public void OpenConnection()
	{
		if (sp != null)
		{
			if (sp.IsOpen)
			{
				sp.Close();
				print("Port was already open");
			}
			else
			{
				sp.Open(); //opening connection
				sp.ReadTimeout = 16;
				print("port opened");
			}

		}
		else
		{
			if (sp.IsOpen)
			{
				print("Port is already open");
			}
			else
			{
				print("Port == null");
			}
		}
	}
}
