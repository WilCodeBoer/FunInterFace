using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickHandler : MonoBehaviour {

	CardFactory factory;
	public GameObject topMenu;

	void Start () {
		if (GameObject.FindObjectOfType<CardFactory> () != null) factory = GameObject.FindObjectOfType<CardFactory> ();
		if(GameObject.FindGameObjectWithTag ("Shop") != null)GameObject.FindGameObjectWithTag ("Shop").GetComponent<Button> ().onClick.AddListener (loadShop);
		if(GameObject.FindGameObjectWithTag ("Main Menu") != null)GameObject.FindGameObjectWithTag ("Main Menu").GetComponent<Button> ().onClick.AddListener (loadMainMenu);
		if(GameObject.FindGameObjectWithTag ("LibraryButton") != null)GameObject.FindGameObjectWithTag ("LibraryButton").GetComponent<Button> ().onClick.AddListener (loadLibrary);
		if (GameObject.FindGameObjectWithTag ("Bronze") != null)GameObject.FindGameObjectWithTag ("Bronze").GetComponent<Button> ().onClick.AddListener (openBronze);
		if (GameObject.FindGameObjectWithTag ("Silver") != null)GameObject.FindGameObjectWithTag ("Silver").GetComponent<Button> ().onClick.AddListener (openSilver);
		if (GameObject.FindGameObjectWithTag ("Gold") != null)GameObject.FindGameObjectWithTag ("Gold").GetComponent<Button> ().onClick.AddListener (openGold);
	}

	void Update(){
		if (topMenu != null) {
			topMenu.transform.GetChild (2).GetComponent<Text> ().text = "Gold: " + (PlayerPrefs.GetInt("Player Gold").ToString());
		}
	}

	void loadMainMenu(){
		SceneManager.LoadScene (0);
	}

	void loadLibrary(){
		SceneManager.LoadScene(2);
	}

	void loadShop(){
		SceneManager.LoadScene(1);
	}

	void openBronze(){
		if (CardFactory.money >= 500) {
			factory.boosterPack ("Bronze");
			Debug.Log ("bought pack");
			int gold = PlayerPrefs.GetInt ("Player Gold");
			PlayerPrefs.SetInt ("Player Gold", gold - 500);
		}
	}
		
	void openSilver(){
		if (CardFactory.money >= 1500) {
			factory.boosterPack ("Silver");
			int gold = PlayerPrefs.GetInt ("Player Gold");
			PlayerPrefs.SetInt ("Player Gold", gold - 1500);
		}
	}

	void openGold(){
		if(CardFactory.money >= 3000){
			factory.boosterPack ("Gold");
			int gold = PlayerPrefs.GetInt ("Player Gold");
			PlayerPrefs.SetInt ("Player Gold", gold - 3000);
		}
	}

	void AddUICard(){
		GameObject cardUI =  GameObject.Instantiate (Resources.Load<GameObject>("Prefabs/CardUI"), GameObject.FindGameObjectWithTag ("LibraryHolder").transform);
		RectTransform card = cardUI.GetComponent<RectTransform> ();
		card.localScale = new Vector3 (1, 1, 1);
	}
}
