using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCardAnimation : MonoBehaviour {

	bool isDown = false;

	Animation anim;

	void Start(){
		anim = gameObject.GetComponent<Animation> ();

		Debug.Log (anim.GetClipCount());
	}

	public void AnimateDown(){
		if (!isDown) {
			isDown = true;
			anim.Play ("ScrollDownCard");
		} else {
			return;
		}
	}

	public void AnimateUp(){
		if (isDown) {
			isDown = false;
			anim.Play ("ScrollUpCard");
		} else {
			return;
		}
	}
}
