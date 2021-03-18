using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Leap.Unity.Interaction;



public class ResetObjects : MonoBehaviour {
	
	// UI dragging place for objects
	public GameObject[] objectsToReset;
		
	// initialize arrays for values
	Vector3[] orgPosition;
	Vector3[] orgVelocity;
	Vector3[] orgAngVel;

	void Start()
	{
		// arrays for values to be saved
		orgPosition = new Vector3[objectsToReset.Length];
		orgVelocity = new Vector3[objectsToReset.Length];
		orgAngVel = new Vector3[objectsToReset.Length];
		
		for(int i = 0; i <=  objectsToReset.Length -1; i++)
		{
			var debug = objectsToReset[i].name;
			orgPosition[i] = objectsToReset[i].transform.position;
			orgVelocity[i] = objectsToReset[i].GetComponent<Rigidbody>().velocity;
			orgAngVel[i] = objectsToReset[i].GetComponent<Rigidbody>().angularVelocity;
			Debug.Log(debug + " start position saved");
		}
	}
	
	public void ResetPos()
	{
		for(int i = 0; i <=  objectsToReset.Length -1; i++)
		{
			var debug = objectsToReset[i].name;
			objectsToReset[i].transform.position = orgPosition[i];
			objectsToReset[i].GetComponent<Rigidbody>().velocity = orgVelocity[i];
			objectsToReset[i].GetComponent<Rigidbody>().angularVelocity = orgAngVel[i];
			Debug.Log(debug + " position reset");
		}
	}
}