using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

public class SaveData  {

	public static CardDatabase cardDatabase = new CardDatabase();
	public static int timesSaved = 0;

	public static void loadAll(string path){
		cardDatabase = LoadCards (path);
		cardDatabase.cards.Sort ();
		foreach (CardData data in cardDatabase.cards) {
			CardFactory.LoadPlaceHolder (data);

		}
		Debug.Log (cardDatabase.cards.Count + " cards loaded");
	}

	public static void LoadCreatures(string path){
		cardDatabase = LoadCards (path);
		cardDatabase.cards.Sort ();
		foreach (CardData data in cardDatabase.cards) {
			if (data.Type == "Creature") {
				CardFactory.LoadPlaceHolder(data);
			}
		}
	}

	public static void LoadSpells(string path){
		cardDatabase = LoadCards (path);
		cardDatabase.cards.Sort ();
		foreach (CardData data in cardDatabase.cards) {
			if (data.Type == "Spell") {
				CardFactory.LoadPlaceHolder(data);
			}
		}
	}

	public static void LoadTraps(string path){
		cardDatabase = LoadCards (path);
		cardDatabase.cards.Sort ();
		foreach (CardData data in cardDatabase.cards) {
			if (data.Type == "Trap") {
				CardFactory.LoadPlaceHolder(data);
			}
		}
	}


	public static void Load(string path){
		cardDatabase = LoadCards (path);
		foreach (CardData data in cardDatabase.cards) {
			CardFactory.LoadPlaceHolder (data);
		}
	}
		
	public static void Save(string path, CardDatabase cards){
		SaveCards (path, cards);
	}

	public static void AddCardData(CardData data){
		cardDatabase.cards.Add (data);
	}

	public static void clearListNull(){
		for (int i = cardDatabase.cards.Count - 1; i >= 0; i--) {
			if (cardDatabase.cards.ElementAt (i) == null) {
				cardDatabase.cards.RemoveAt (i);
				Debug.Log ("Removed element " + i);
			}
		}
	}

	public static void ClearDataBase(){
		cardDatabase.cards.Clear ();
	}

	public static CardDatabase LoadCards(string path){
		XmlSerializer serializer = new XmlSerializer (typeof(CardDatabase));

		FileStream stream = new FileStream (path, FileMode.Open);

		cardDatabase = serializer.Deserialize (stream) as CardDatabase;

		stream.Close ();

		return cardDatabase;
	}

	public static void SaveCards(string path, CardDatabase cards){
		XmlSerializer serializer = new XmlSerializer (typeof(CardDatabase));

		FileStream stream = new FileStream (path, FileMode.Create);

		serializer.Serialize (stream, cards);

		stream.Close ();
	}
}
