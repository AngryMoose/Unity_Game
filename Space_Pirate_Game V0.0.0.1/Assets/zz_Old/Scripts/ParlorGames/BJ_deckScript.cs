using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BJ_deckScript : MonoBehaviour
{
    public Sprite[] cardSprites;
    int[] cardValues = new int[53];
    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetCardValues();
    }


    void GetCardValues()
    {
        int num = 0;
        // Loop to assign values to the cards
        for(int i = 0; i < cardSprites.Length; i++) 
        {
            // count up to the amount of cards, 52
            num = i;
            
            // if there is a remainder after i/13, then remainder is used as the value unless over 10, then use 10
            num %= 13;
            
            if(num > 10 || num == 0)
            {
                num = 10;
            }
            cardValues[i] = num++;
        }
        
    }

    public void Shuffle()
    {
        // standard array data swapping technique
        for(int i = cardSprites.Length - 1; i > 0; --i)
        {
            // takes away the decimal, gives us a random number within deck of card
            int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cardSprites.Length - 1) + 1;
            Sprite face = cardSprites[i];
            cardSprites[i] = cardSprites[j];
            cardSprites[j] = face;

            int value = cardValues[i];
            cardValues[i] = cardValues[j];
            cardValues[j] = value;
        }
        currentIndex = 1;
    }

    public int DealCard(BJ_cardScript cardScript)
    {
        cardScript.SetSprite(cardSprites[currentIndex]);
        cardScript.SetValue(cardValues[currentIndex++]);
        return cardScript.GetValueOfCard();
    }

    public Sprite GetCardBack()
    {
        return cardSprites[0];  
    }
}
