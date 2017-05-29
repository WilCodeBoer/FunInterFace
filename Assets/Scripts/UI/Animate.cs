using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour {

	void Start () {
		this.GetComponent<Animation> ().Play ();
	}

}
