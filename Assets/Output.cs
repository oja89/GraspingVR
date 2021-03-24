using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Vibrate(string caller)
	{
		Debug.Log("Please vibrate " + caller);
		if (caller == "L_index_end")
			Debug.Log("it was L-index");		
		
	}
}
