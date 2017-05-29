using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPlaceHolder : MonoBehaviour {

	public CardData data = new CardData();

	void Start () {
		this.transform.GetChild (0).GetComponent<Text> ().text = data.Name;
		this.transform.GetChild (1).GetComponent<Text> ().text += data.Level.ToString();
		this.transform.GetChild (2).GetComponent<Text> ().text += data.Element;
		this.transform.GetChild (3).GetComponent<Text> ().text = data.Type;
		this.transform.GetChild (4).GetComponent<Text> ().text += data.Value.ToString();
	}
}