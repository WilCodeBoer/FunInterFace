using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.IO;

public class CardFactory : MonoBehaviour {
	GameObject cardbase;
	GameObject canvas;

	public GameObject boughtScreen;
	public GameObject[] packScreens;
    public string[] type = new string[2];
	public string[] rarity = new string[2];
	public string[] elements = new string[3];
	public List<string> creatures = new List<string> ();
	public List<string> spells = new List<string> ();
	public List<string> traps = new List<string> ();
	public List<string> abilities = new List<string> ();
	public static List<GameObject> holders = new List<GameObject>();

	public static string cardDataPath;
	public static int money;

	void OnApplicationQuit(){
		PlayerPrefs.SetInt("Player Gold", money);
	}
		
	void Awake() { 
		if (PlayerPrefs.HasKey ("Player Gold")) {
			money = PlayerPrefs.GetInt("Player Gold") != 0 ? PlayerPrefs.GetInt("Player Gold") : 5000;
		} else {
			money = 5000;
		}
		canvas = GameObject.FindGameObjectWithTag ("Canvas");
		cardDataPath = System.IO.Path.Combine (Application.dataPath, "Resources/cards.xml"); 
		cardbase = Resources.Load<GameObject> ("Prefabs/BaseCard");
		if(GameObject.FindGameObjectWithTag("StarterHolder") != null)holders.Add(GameObject.FindGameObjectWithTag("StarterHolder"));
	}

	public GameObject createCreature(int level){
		RectTransform holder = CardFactory.GetHolder ("Holder");
		GameObject creatureCard = GameObject.Instantiate (cardbase, holder.transform);
		holder.GetComponent<CardSpot> ().card = creatureCard;
		CardData card;
		card = creatureCard.GetComponent<BaseCard> ().data;

		card.ImageFrame = "ImageFrame";

		card.Type = type[2];
		card.Frame = card.Type;
		card.Element = elements [Random.Range (0, elements.Length)];

		switch (card.Element) {
		case "Earth":
			card.Name = creatures [Random.Range (0, 8)];
			break;
		case "Water":
			card.Name = creatures [9];
			break;
		case "Wind":
			card.Name = creatures [10];
			break;
		case "Fire":
			card.Name = creatures [11];
			break;
		}

		card.Level = level;
		card.Value = level * 50;
		if (card.Level < 4) {
			card.Rarity = rarity [0];
			card.Abilities = 1;	
		} else if (card.Level > 3 && card.Level < 7) {
			card.Rarity = rarity [1];
			card.Abilities = 2;
		} else if (card.Level > 6) {
			card.Rarity = rarity [2];
			card.Abilities = 3;
		}

		switch (card.Abilities) {
		case 1:
			card.AbilityOne = string.Empty;
			card.AbilityTwo = abilities.ElementAt (Random.Range (0, 2));
			card.AbilityThree = string.Empty;
			break;
		case 2:
			card.AbilityOne = abilities.ElementAt (Random.Range (0, 2));
			card.AbilityTwo = string.Empty;
			card.AbilityThree = abilities.ElementAt (Random.Range (3, 6));
			break;
		case 3:
			card.AbilityOne = abilities.ElementAt (Random.Range (0, 2));
			card.AbilityTwo = abilities.ElementAt (Random.Range (3, 6));
			card.AbilityThree = abilities.ElementAt (Random.Range (7, 9));
			break;
		}

		card.Image = card.Name;
		creatureCard.name = card.Element + " " + card.Name + " Level " + card.Level;

		RectTransform goRect = creatureCard.GetComponent<RectTransform> ();
		goRect.position = holder.position;
		goRect.localScale = new Vector3 (0.4152496f, 0.4152496f, 0.4152496f);
		SaveData.AddCardData (card);
		creatureCard.tag = "Card";
		return creatureCard;
	}

	public GameObject createTrap(){
		RectTransform holder = CardFactory.GetHolder ("Holder");
		GameObject trapCard = GameObject.Instantiate (cardbase, holder.transform);
		holder.GetComponent<CardSpot> ().card = trapCard;
		CardData card;
		card = trapCard.GetComponent<BaseCard> ().data;

		card.ImageFrame = "ImageFrame";
		card.Abilities = 1;
		card.Element = "Trap";
		card.Type = type [1];
		card.Frame = card.Type;

		card.Name = traps.ElementAt(Random.Range (0, traps.Count));

		switch (card.Name) {
		case "Black Hole":
			card.Level = 5;
			card.AbilityTwo = "When an enemy attacks destroy that creature";
			card.Rarity = rarity [2];
			break;
		case "Spikes":
			card.Level = 2;
			card.AbilityTwo = "Shoot spikes around the target: 10 damage each turn for 3 turns";
			card.Rarity = rarity [0];
			break;
		case "Swarm":
			card.Level = 3;
			card.AbilityTwo = "When an enemy attack leech 20 health";
			card.Rarity = rarity [1];
			break;
		case "Pitfall":
			card.Level = 4;
			card.AbilityTwo = "When an enemy attacks disable that creature for 1 turn";
			card.Rarity = rarity [1];
			break;
		case "Mimic":
			card.Level = 5;
			card.AbilityTwo = "Mimic one of the opponents creatures";
			card.Rarity = rarity [2];
			break;	
		}
		card.Value = card.Level * 75;
		card.Image = card.Name;
		trapCard.name = card.Element + " " + card.Name + " Level " + card.Level;

		RectTransform goRect = trapCard.GetComponent<RectTransform> ();
		goRect.position = holder.position;
		goRect.localScale = new Vector3 (0.4152496f, 0.4152496f, 0.4152496f);
		SaveData.AddCardData (card);
		trapCard.tag = "Card";
		return trapCard;
	}

	public GameObject createSpell(){
		RectTransform holder = CardFactory.GetHolder ("Holder");
		GameObject spellCard = GameObject.Instantiate (cardbase, holder.transform);
		holder.GetComponent<CardSpot> ().card = spellCard;
		CardData card;
		card = spellCard.GetComponent<BaseCard> ().data;

		card.ImageFrame = "ImageFrame";
		card.Abilities = 1;
		card.Element = "Spell";		
		card.Type = type [0];
		card.Frame = card.Type;
		card.Name = spells.ElementAt(Random.Range (0, traps.Count));

		switch (card.Name) {
		case "Fireball":
			card.Level = 2;
			card.AbilityTwo = "Shoot a fireball: 25 damage";
			card.Rarity = rarity [0];
			break;
		case "Ice Spike":
			card.Level = 2;
			card.AbilityTwo = "Shoot spikes of ice: 25 damage";
			card.Rarity = rarity [0];
			break;
		case "Heal":
			card.Level = 4;
			card.AbilityTwo = "Heal yourself for 50 health!";
			card.Rarity = rarity [1];
			break;
		case "Armor":
			card.Level = 4;
			card.AbilityTwo = "Shield yourself for 50 health!";
			card.Rarity = rarity [1];
			break;
		case "Mind Control":
			card.Level = 5;
			card.AbilityTwo = "Steal one creature from your opponent";
			card.Rarity = rarity [2];
			break;

		}
		card.Value = card.Level * 75;
		card.Image = card.Name;
		spellCard.name = card.Element + " " + card.Name + " Level " + card.Level;

		RectTransform goRect = spellCard.GetComponent<RectTransform> ();
		goRect.position = holder.position;
		goRect.localScale = new Vector3 (0.4152496f, 0.4152496f, 0.4152496f);
		SaveData.AddCardData (card);
		spellCard.tag = "Card";
		return spellCard;
	}

	public Transform BoosterPackSlot(string boosterPack){
		return null;
	}

	void Save(){
		SaveData.Save (cardDataPath, SaveData.cardDatabase);
	}

	public void boosterPack(string packColor){
		boughtScreen.SetActive (true);
		canvas.SetActive (false);
		if (boughtScreen.activeSelf == true) {
			switch (packColor) {
			case "Bronze":
				packScreens[0].SetActive (true);
				packScreens[1].SetActive (false);
				packScreens[2].SetActive (false);
				if (Random.Range (1, 10) < 5) {
					createSpell ();
				} else {
					createTrap ();
				}
				createCreature (Random.Range (1, 4));
				createCreature (Random.Range (1, 4));
				createCreature (7);
					break;
			case "Silver":
				packScreens[0].SetActive (false);
				packScreens[1].SetActive (true);
				packScreens[2].SetActive (false);
				if (Random.Range (1, 10) < 5) {
					createSpell ();
				} else {
					createTrap ();
				}
				if (Random.Range (1, 10) < 5) {
					createSpell ();
				} else {
					createTrap ();
				}
				createCreature (Random.Range (3, 6));
				createCreature (Random.Range (3, 6));
				createCreature (Random.Range (5, 7));
				createCreature (8);
				break;
			case "Gold":
				packScreens[0].SetActive (false);
				packScreens[1].SetActive (false);
				packScreens[2].SetActive (true);
				if (Random.Range (1, 10) < 5) {
					createSpell ();
				} else {
					createTrap ();
				}
				if (Random.Range (1, 10) < 5) {
					createSpell ();
				} else {
					createTrap ();
				}
				createCreature (Random.Range (5, 8));
				createCreature (Random.Range (5, 8));
				createCreature (Random.Range (5, 8));
				createCreature (Random.Range (7, 9));
				createCreature (Random.Range (7, 9));
				createCreature (10);
				break;
			}
		}
		Save ();
	}

	public static RectTransform GetHolder(string holder){
		GameObject[] placeHolders = GameObject.FindGameObjectsWithTag(holder);

		foreach (GameObject place in placeHolders) {
			if (!place.GetComponent<CardSpot> ().hasCard) {
				place.GetComponent<CardSpot>().hasCard = true;
				return place.GetComponent<RectTransform> ();
			}
		}
		return null;
	}

	public static RectTransform GetViewHolder(string tag){
		GameObject holder = GameObject.FindGameObjectWithTag (tag);
		CardSpot spot = holder.GetComponent<CardSpot> ();

		if (!spot.hasCard) {
			spot.hasCard = true;
			return holder.GetComponent<RectTransform> ();
		} else {
			Destroy (spot.card);
			return holder.GetComponent<RectTransform>();
		}
	}

	public static GameObject showCard(CardData data){
		RectTransform holder = GetViewHolder ("Holder");
		GameObject go = GameObject.Instantiate (Resources.Load<GameObject> ("Prefabs/BaseCard"), holder.transform);
		BaseCard card = go.GetComponent<BaseCard> ();
		RectTransform goRect = go.GetComponent<RectTransform> ();
		goRect.position = holder.position;
		goRect.localScale = new Vector3 (0.59f, 0.54f, 0.4152496f);
		card.data = data;
		card.tag = "Card";
		holder.GetComponent<CardSpot> ().card = go;
		return go;
	}

	public static GameObject loadCard(CardData data){
		RectTransform holder = CardFactory.GetHolder("Holder"); 
		GameObject go = GameObject.Instantiate (Resources.Load<GameObject> ("Prefabs/BaseCard"), holder.transform);
		BaseCard card = go.GetComponent<BaseCard> ();
		RectTransform goRect = go.GetComponent<RectTransform> ();
		goRect.position = holder.position;
		goRect.localScale = new Vector3 (0.4152496f, 0.4152496f, 0.4152496f);
		card.data = data;
		card.tag = "Card";
		return go;
	}

	public static GameObject LoadPlaceHolder(CardData data){
		RectTransform holder = GameObject.FindGameObjectWithTag("LibraryHolder").GetComponent<RectTransform>();
		GameObject go = GameObject.Instantiate (Resources.Load<GameObject> ("Prefabs/CardUI"), holder.transform);
		CardPlaceHolder card = go.GetComponent<CardPlaceHolder> ();
		card.data = data;
		card.tag = "PlaceHolder";
		go.transform.localScale = new Vector3 (1, 1, 1);
		return go;

	}
}
	