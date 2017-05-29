using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour {
	void Start(){
		gameObject.GetComponent<Button>().onClick.AddListener(() => {
			Application.Quit();
		});
	}
}
