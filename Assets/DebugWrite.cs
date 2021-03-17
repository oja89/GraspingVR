using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugWrite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log ("Start DEBUG");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log ("Update DEBUG");
    }
	public static void WriteLog() 
	{
		Debug.Log ("WriteLog");
	}
}
