using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Leap.Unity.Interaction;



public class ObjectManipulation : MonoBehaviour {
	
	// UI dragging place for objects
	public GameObject[] myObjects;
		
	// initialize arrays for values
	Vector3[] orgPosition;
	Vector3[] orgVelocity;
	Vector3[] orgAngVel;

	void Start()
	{
		// arrays for values to be saved
		orgPosition = new Vector3[myObjects.Length];
		orgVelocity = new Vector3[myObjects.Length];
		orgAngVel = new Vector3[myObjects.Length];
		
		for(int i = 0; i <=  myObjects.Length -1; i++)
		{
			GameObject modding = myObjects[i];
			var debug = modding.name;
			orgPosition[i] = modding.transform.position;
			orgVelocity[i] = modding.GetComponent<Rigidbody>().velocity;
			orgAngVel[i] = modding.GetComponent<Rigidbody>().angularVelocity;
			Debug.Log(debug + " start position saved");
		}
	}
	
	public void ResetPos()
	{
		for(int i = 0; i <=  myObjects.Length -1; i++)
		{
			var debug = myObjects[i].name;
			myObjects[i].transform.position = orgPosition[i];
			myObjects[i].GetComponent<Rigidbody>().velocity = orgVelocity[i];
			myObjects[i].GetComponent<Rigidbody>().angularVelocity = orgAngVel[i];
			Debug.Log(debug + " position reset");
		}
	}
}