using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BJ_playerScript : MonoBehaviour
{
    // This script is for both player and dealer

    public BJ_cardScript cardScript;
    public BJ_deckScript deckScript;

    // total value of hand
    public int handValue = 0;

    //Betting Money
    //private int money = PlayerManager.instance.currency;
    private int money = 1000;

    // array of card objects on table
    public GameObject[] hand;
    // index of next card to be turned over
    public int cardIndex = 0;
    //tracking aces for 1 to 11 conversions
    List<BJ_cardScript> aceList = new List<BJ_cardScript>();

    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    public int GetCard()
    {
        // get a card, use deal card to assign spriute and value to card on table
        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<BJ_cardScript>());
        // show card on game screen
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        // add card value to running total of hand
        handValue += cardValue;

        if(cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<BJ_cardScript>());

        }
        //AceCheck();
        cardIndex++;
        return handValue;

    }
}
