using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlackJackManager : MonoBehaviour
{
    [SerializeField] Button dealButton;
    [SerializeField] Button hitButton;
    [SerializeField] Button stayButton;
    [SerializeField] Button betButton;

    [SerializeField] TextMeshProUGUI stayButtonText;
    [SerializeField] Text scoreText;
    [SerializeField] Text dealerScoreText;
    [SerializeField] Text betText;
    [SerializeField] Text cashText;
    [SerializeField] Text mainText;

    [SerializeField] int intBet = 1;

    private int stayClicks = 0;

    [SerializeField] GameObject hideCard;

    //access to player/dealer hand
    public BJ_playerScript playerScript;
    public BJ_playerScript dealerScript;

    int pot = 0;

    // Start is called before the first frame update
    void Start()
    {
        dealButton.onClick.AddListener(() => DealClicked());
        hitButton.onClick.AddListener(() => HitClicked());
        stayButton.onClick.AddListener(() => StayClicked());
        betButton.onClick.AddListener(() => BetClicked());
    }

    private void BetClicked()
    {

        playerScript.AdjustMoney(-intBet);
        cashText.text = playerScript.GetMoney().ToString();
        pot += (intBet * 2); // *2 because dealer matches the bet
        betText.text = pot.ToString();
    }

    private void DealClicked()
    {
        // Reset round, hide text, prep for new hand
        playerScript.ResetHand();
        dealerScript.ResetHand();
        // Hide deal hand score at start of deal
        mainText.gameObject.SetActive(false);
        dealerScoreText.gameObject.SetActive(false);
        GameObject.Find("Deck").GetComponent<BJ_deckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();
        // update scores displayed
        scoreText.text = "Player Hand: " + playerScript.handValue.ToString();
        dealerScoreText.text = "Dealer Hand: " + playerScript.handValue.ToString();
        // Enable to hide one of the dealer's cards
        hideCard.GetComponent<Renderer>().enabled = true;
        //adjust visability of buttons
        dealButton.gameObject.SetActive(false);
        hitButton.gameObject.SetActive(true);
        stayButton.gameObject.SetActive(true);
        stayButtonText.text = "Stay";
        // set standard pot size
        pot = 40;
        playerScript.AdjustMoney(-20);
        cashText.text = playerScript.GetMoney().ToString();
    }

    private void HitClicked()
    {
        dealerScoreText.gameObject.SetActive(true);
        if (playerScript.cardIndex <= 10)
        {
            playerScript.GetCard();
            scoreText.text = "Player Hand: " + playerScript.handValue.ToString();
            if(playerScript.handValue > 20)
            {
                RoundOver();
            }
        }
    }

    private void StayClicked()
    {
        dealerScoreText.gameObject.SetActive(true);
        stayClicks++;
        if (stayClicks > 1) RoundOver();
        HitDealer();
        stayButtonText.text = "Call";

    }

    private void HitDealer()
    {
        while(dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            dealerScoreText.gameObject.SetActive(true);
            dealerScoreText.text = "Dealer Hand: " + dealerScript.handValue.ToString();
            if (dealerScript.handValue > 20) RoundOver();
        }
    }

    void RoundOver()
    {
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = dealerScript.handValue == 21;

        if (stayClicks < 2 && !playerBust && !dealerBust && !player21 & !dealer21) return;
        bool roundOver = true;
        //All bust, bet returned
        if(playerBust && dealerBust)
        {
            mainText.text = "All Bust: Bets Returned";
            playerScript.AdjustMoney(pot / 2);
        }

        else if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            mainText.text = "Dealer Wins";
        }

        else if (dealerBust || playerScript.handValue > dealerScript.handValue)
        {
            mainText.text = "You Win!";
            playerScript.AdjustMoney(pot);
        }
         else if (playerScript.handValue == dealerScript.handValue)
        {
            mainText.text = "Push: Bets Returned";
            playerScript.AdjustMoney(pot / 2);
        }

        else
        {
            roundOver = false;
        }
        if(roundOver)
        {
            hitButton.gameObject.SetActive(false);
            stayButton.gameObject.SetActive(false);
            dealButton.gameObject.SetActive(true);
            mainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Renderer>().enabled = false;
            cashText.text = playerScript.GetMoney().ToString();
            stayClicks = 0;
        }
    }
}
