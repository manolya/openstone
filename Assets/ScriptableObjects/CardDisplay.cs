using System;
using System.Collections;
using System.Collections.Generic;
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

    // Use this for initialization
    void Start () {
            nameText.text = name;
            descriptionText.text = description;

            artworkImage.sprite = artwork;

            manaText.text = manaCost.ToString();
            attackText.text = attack.ToString();
            healthText.text = health.ToString();    
	}
    void RecieveStats(object[] cardstats)
    {
        cardstats[0] = name;
        cardstats[1] = description;
        cardstats[2] = artworkImage;
        cardstats[3] = manaCost;
        cardstats[4] = attack;
        cardstats[5] = health;
        cardstats[6] = maxindeck;
    }
}
