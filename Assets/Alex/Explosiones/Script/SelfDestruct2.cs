using UnityEngine;
using System.Collections;


namespace InguzPings
{


public class SelfDestruct2 : MonoBehaviour {
	public float selfdestruct_in = 4; // Setting this to 0 means no selfdestruct.

	void Start () {
		if ( selfdestruct_in != 0){ 
			Destroy (gameObject, selfdestruct_in);
		}
	}
}


}
