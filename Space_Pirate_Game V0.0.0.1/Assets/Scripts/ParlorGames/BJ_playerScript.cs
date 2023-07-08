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
        AceCheck();
        cardIndex++;
        return handValue;

    }

    // search for needed ace conversion, 1 to 11 or vice versa
    public void AceCheck()
    {
        // for each ace in the list check
        foreach(BJ_cardScript ace in aceList)
        {
            if(handValue + 10 < 22 && ace.GetValueOfCard() == 1)
            {
                //if converting ace, adjust card object value and hand
                ace.SetValue(11);
                handValue += 10;
            }
            else if(handValue > 21 && ace.GetValueOfCard() == 11)
            {
                ace.SetValue(1);
                handValue -= 10;
            }
        }
    }

    // Add or subtract from money for bets
    public void AdjustMoney(int amount)
    {
        money += amount;
        PlayerManager.instance.currency = money;
    }

    // output players current money amount
    public int GetMoney()
    {
        return money;
    }

    public void ResetHand()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i].GetComponent<BJ_cardScript>().ResetCard();
            hand[i].GetComponent<Renderer>().enabled = false;
        }
        cardIndex = 0;
        handValue = 0;
        aceList = new List<BJ_cardScript>();
    }
}
