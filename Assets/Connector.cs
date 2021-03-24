using Leap.Unity.Attributes;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using System.Collections;




public class Connector : MonoBehaviour
// a module for testing and troubleshooting
// not to be used in final demo

// used to connect VR events to Feedback module
{	// key1 for ...
	//public string key1;	[SerializeField]
	public KeyCode key1 = KeyCode.A;
	[SerializeField]
    private UnityEvent _OnKey1 = new UnityEvent();
	public Action OnKey1 = () => { };
	
	public KeyCode key2 = KeyCode.S;
	[SerializeField]
    private UnityEvent _OnKey2 = new UnityEvent();
	public Action OnKey2 = () => { };

	public KeyCode key3 = KeyCode.D;
	[SerializeField]
    private UnityEvent _OnKey3 = new UnityEvent();
	public Action OnKey3 = () => { };


    // Start is called before the first frame update
    void Start()
    {
        OnKey1 += _OnKey1.Invoke;
		OnKey2 += _OnKey2.Invoke;
		OnKey3 += _OnKey3.Invoke;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(key1))
		{
			OnKey1();
		}
		if (Input.GetKey(key2))
		{
			OnKey2();
		}
		if (Input.GetKey(key3))
		{
			OnKey3();
		}
    }
}
