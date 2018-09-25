using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	public Text nameText;
	public Text descriptionText;

	public Image artworkImage;

	public Text manaText;
	public Text attackText;
	public Text healthText;

    public new string name;
    public string description;

    public Sprite artwork;

    public int manaCost;
    public int attack;
    public int health;
    public int maxindeck;
    public int cardID;

    // Use this for initialization
    void Start () {
            nameText.text = name;
            descriptionText.text = description;

            artworkImage.sprite = artwork;

            manaText.text = manaCost.ToString();
            attackText.text = attack.ToString();
            healthText.text = health.ToString();    
	}
    void GetID(int cardid)
    {
        cardID = cardid;
    }
    IEnumerator RecieveStats(List<Cardjson> cardstats)
    {
        Cardjson[] cardstatsarray = cardstats.ToArray();
        WWW image = new WWW(cardstatsarray[cardID].img);
        while (!image.isDone)
        {
            yield return null;
        }
        print(cardstatsarray[cardID].img);
        name = cardstatsarray[cardID].name;
        description = cardstatsarray[cardID].description;
        artworkImage.GetComponent<RawImage>().texture = image.texture;
        manaCost = cardstatsarray[cardID].manacost;
        attack = cardstatsarray[cardID].atk;
        health = cardstatsarray[cardID].hp;
        maxindeck = cardstatsarray[cardID].maxindeck;

        nameText.text = name;
        descriptionText.text = description;

        artworkImage.sprite = artwork;

        manaText.text = manaCost.ToString();
        attackText.text = attack.ToString();
        healthText.text = health.ToString();
    }       
}