using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BackToShop : MonoBehaviour {
	public GameObject shop;

	void OnEnable(){
		this.GetComponent<Button> ().onClick.AddListener (goBack);
	}

	void OnDisable(){
		this.GetComponent<Button> ().onClick.RemoveListener (goBack);
	}

	void goBack(){
		foreach (GameObject card in GameObject.FindGameObjectsWithTag("Card")) {
			Destroy (card);
		}
		shop.SetActive (true);
		this.gameObject.transform.parent.gameObject.SetActive (false);
	}
}
