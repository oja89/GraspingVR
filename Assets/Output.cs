using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
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

	private static SerialPort sp = new SerialPort("COM3", 9600);

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

		//string Rindex = fingers["R_index_end"].ToString();
		//string Rmiddle = fingers["R_middle_end"].ToString();
		//string Rthumb = fingers["R_thumb_end"].ToString();
		//string message = "<" + Rthumb + "," + Rindex + "," + Rmiddle + ">";
		//sp.Write(message);

	}
	
	public void Vibrate(string caller, int direction)
	{
		// change value in the dictionary
		fingers[caller] = direction;
		SetVibrations();

		/*
		if (direction == 100) { 
			Debug.Log("Please vibrate " + caller);
		}
		else Debug.Log("Stop vibrating " + caller);


		// call for change in arduino?
		if(caller == "L_index_end" && direction == 100)
        {
			sp.Write("<0,100,0>");
		}
		else if(caller == "L_index_end" && direction == 0)
        {
			sp.Write("<0,0,0>");
		}
		
		else if(caller == "L_middle_end")
        {
			sp.Write("<0,0,100>");
        }
		else if(caller == "L_thumb_end")
        {
			sp.Write("<100,0,0>");
        }*/

		
	}

	public void SetVibrations()
    {
		// get values from dict and send to arduino
		string Rindex = fingers["R_index_end"].ToString();
		string Rmiddle = fingers["R_middle_end"].ToString();
		string Rthumb = fingers["R_thumb_end"].ToString();
		string message = "<" + Rthumb + "," + Rindex + "," + Rmiddle + ">";
		sp.Write(message);
	}




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
