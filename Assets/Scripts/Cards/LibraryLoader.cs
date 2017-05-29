using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryLoader : MonoBehaviour {

	void OnEnable(){
		SaveData.loadAll (CardFactory.cardDataPath);
		allowCardSelling();
		setFilters ();
	}

	void OnDisable(){
		CardFactory.holders.Clear ();
	}

	void setFilters(){
		foreach (GameObject filter in GameObject.FindGameObjectsWithTag("Filter")) {
			filter.GetComponent<Button> ().onClick.AddListener (() => {
				setFilter(filter.name);
			});
		}
	}

	void allowCardSelling(){
		foreach (GameObject sellButton in GameObject.FindGameObjectsWithTag("Sell")) {
			sellButton.GetComponent<Button> ().onClick.AddListener (() => {
				sellCard (sellButton.transform.parent.gameObject);
			});
		}
		foreach (GameObject viewCard in GameObject.FindGameObjectsWithTag("PlaceHolder")) {
			viewCard.GetComponent<Button> ().onClick.AddListener (() => {
				ShowCard (viewCard.gameObject);
			});
		}
	}

	void sellCard(GameObject card){
		CardPlaceHolder baseCard = card.GetComponent<CardPlaceHolder> ();
		PlayerPrefs.SetInt("Player Gold", CardFactory.money += baseCard.data.Value);
		SaveData.cardDatabase.cards.Remove (baseCard.data);
		SaveData.Save (CardFactory.cardDataPath, SaveData.cardDatabase);

		CardSpot spot = GameObject.FindObjectOfType<CardSpot> ();

		if (spot.hasCard) {
			if (spot.card.GetComponent<BaseCard> ().data == baseCard.data) {
				Destroy (spot.card);
				GameObject.FindObjectOfType<CurrentCardAnimation> ().AnimateUp ();
				GameObject.FindObjectOfType<DescriptionAnimation> ().AnimateUp ();
				spot.hasCard = false;
			}
		}
		Destroy (card);
	}

	GameObject ShowCard(GameObject card){
		CardPlaceHolder uiHolder = card.GetComponent<CardPlaceHolder> ();
		GameObject go = CardFactory.showCard (uiHolder.data);
		GameObject.FindObjectOfType<CurrentCardAnimation> ().AnimateDown ();
		GameObject.FindObjectOfType<DescriptionAnimation> ().AnimateDown ();
		return go;
	}

	public void setFilter(string filter){
		switch (filter) {
			case "Creature":
				foreach (GameObject holder in GameObject.FindGameObjectsWithTag("PlaceHolder")) {
					Destroy (holder);
				}
				SaveData.LoadCreatures (CardFactory.cardDataPath);
				allowCardSelling();
				break;
			case "Trap":
				foreach (GameObject holder in GameObject.FindGameObjectsWithTag("PlaceHolder")) {
					Destroy (holder);
				}
				SaveData.LoadTraps (CardFactory.cardDataPath);
				allowCardSelling();
				break;
			case "Spell":
				foreach (GameObject holder in GameObject.FindGameObjectsWithTag("PlaceHolder")) {
					Destroy (holder);
				}
				SaveData.LoadSpells (CardFactory.cardDataPath);
				allowCardSelling();
				break;
			case "All":
				foreach (GameObject holder in GameObject.FindGameObjectsWithTag("PlaceHolder")) {
					Destroy (holder);
				}
				SaveData.loadAll (CardFactory.cardDataPath);
				allowCardSelling();
				break;
		}
	}
}

