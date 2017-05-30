using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.Linq;
using System;

public class BaseCard : MonoBehaviour {

	public CardData data = new CardData();

	void Start(){
		this.transform.GetChild (0).GetComponent<Text> ().text = data.Element;
		this.transform.GetChild (1).GetComponent<Text> ().text = data.Level.ToString();
		this.transform.GetChild (2).GetComponent<Text> ().text = data.Name;
		this.transform.GetChild (3).GetChild (0).GetComponent<Image> ().sprite = Resources.Load<Sprite>("Cards/" + data.ImageFrame);
		this.transform.GetChild (3).GetChild (1).GetComponent<Image> ().sprite = Resources.Load<Sprite>("Images/" + data.Image);
		this.transform.GetChild (4).GetChild (0).GetComponent<Text> ().text = data.AbilityOne;
		this.transform.GetChild (4).GetChild (1).GetComponent<Text> ().text = data.AbilityTwo;
		this.transform.GetChild (4).GetChild (2).GetComponent<Text> ().text = data.AbilityThree;
		this.transform.GetChild (5).GetComponent<Text> ().text = data.Copyright;
		this.transform.GetChild (6).GetComponent<Text> ().text = data.Value.ToString ();
		this.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Cards/" + data.Rarity);

		switch (data.Type) {
			case "Trap":
				this.transform.GetChild (7).gameObject.SetActive (true);
				break;
			case "Spell":
				this.transform.GetChild (8).gameObject.SetActive (true);
				break;
			case "Creature": 
				this.transform.GetChild (9).gameObject.SetActive (true);
				break;
		}
	}
}
	

public class CardData : IComparable<CardData> {
	[XmlAttribute("Type")]
	public string Type;
	[XmlAttribute("Frame")]
	public string Frame;
	[XmlAttribute("Color")]
	public string Rarity{ get; set; }
	[XmlAttribute("Element")]
	public string Element;
	[XmlAttribute("Level")]
	public int Level;
	[XmlAttribute("Name")]
	public string Name;
	public int CompareTo(CardData other){
		return Name.CompareTo (other.Name);
	}
	[XmlAttribute("Value")]
	public int Value;
	[XmlAttribute("ImageFrame")]
	public string ImageFrame { get; set; }
	[XmlAttribute("Image")]
	public string Image { get; set; }
	[XmlAttribute("Abilities")]
	public int Abilities;
	[XmlAttribute("Copyright")]
	public string Copyright;
	[XmlAttribute("AbilityOne")]
	public string AbilityOne;
	[XmlAttribute("AbilityTwo")]
	public string AbilityTwo;
	[XmlAttribute("AbilityThree")]
	public string AbilityThree;
}
