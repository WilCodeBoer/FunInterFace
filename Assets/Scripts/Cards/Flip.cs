using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flip : MonoBehaviour {
	void OnDisable(){
		this.gameObject.GetComponent<Button> ().onClick.RemoveListener (playAnimation);
	} 

	void OnEnable(){
		this.gameObject.GetComponent<Button> ().onClick.AddListener (playAnimation);
	}
	void playAnimation(){
		gameObject.transform.parent.GetComponent<Animation> ().Play ();
		if (!gameObject.transform.parent.GetComponent<Animation> ().isPlaying) {
			this.gameObject.SetActive (false);
		}
	}
}
