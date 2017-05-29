using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpot : MonoBehaviour {
	public GameObject card;
	public bool hasCard;

	void OnDisable(){
		hasCard = false;
	}
}
