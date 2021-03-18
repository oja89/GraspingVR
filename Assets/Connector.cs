using Leap.Unity.Attributes;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using System.Collections;




public class Connector : MonoBehaviour
// used to connect VR events to Feedback module
{	// key1 for ...
	public string key1;
	[SerializeField]
    private UnityEvent _OnKey1 = new UnityEvent();
	public Action OnKey1 = () => { };
	
	public string key2;	[SerializeField]
    private UnityEvent _OnKey2 = new UnityEvent();
	public Action OnKey2 = () => { };



    // Start is called before the first frame update
    void Start()
    {
        OnKey1 += _OnKey1.Invoke;
		OnKey2 += _OnKey2.Invoke;
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
    }
}
