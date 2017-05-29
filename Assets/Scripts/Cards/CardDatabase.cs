using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("CardDatabase")]
public class CardDatabase {
	[XmlArray("Cards")]
	[XmlArrayItem("Card")]
	public List<CardData> cards = new List<CardData>();
}
