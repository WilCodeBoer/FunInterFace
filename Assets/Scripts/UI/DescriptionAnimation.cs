using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionAnimation : MonoBehaviour {

	bool isDown = false;

	Animation anim;

	void Start(){
		anim = gameObject.GetComponent<Animation> ();

		Debug.Log (anim.GetClipCount());
	}

	public void AnimateDown(){
		if (!isDown) {
			isDown = true;
			anim.Play ("ScrollDownDescription");
		} else {
			return;
		}
	}

	public void AnimateUp(){
		if (isDown) {
			isDown = false;
			anim.Play ("ScrollUpDescription");
		} else {
			return;
		}
	}
}