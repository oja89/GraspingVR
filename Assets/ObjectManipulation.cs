using UnityEngine;
using UnityEngine.UI;
using System.Linq;




public class ObjectManipulation : MonoBehaviour {
	
	[SerializeField]	
	GameObject objectToDestroy;

	
	//Called when Button is clicked
	int debugPress() {
	Debug.Log("Pressed");
	return 1;
	
	}
}