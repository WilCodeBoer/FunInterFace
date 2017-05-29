using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToSop : MonoBehaviour {

	void Start(){
		this.GetComponent<Button> ().onClick.AddListener (() => {
			SceneManager.LoadScene(1);
		});
	}
}
