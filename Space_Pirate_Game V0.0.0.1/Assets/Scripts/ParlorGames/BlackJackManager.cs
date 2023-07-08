using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackJackManager : MonoBehaviour
{
    [SerializeField] Button dealButton;
    [SerializeField] Button hitButton;
    [SerializeField] Button stayButton;
    [SerializeField] Button betButton;

    //access to player/dealer hand
    public BJ_playerScript playerScript;
    public BJ_playerScript dealerScript;

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
        throw new NotImplementedException();
    }

    private void DealClicked()
    {
        GameObject.Find("Deck").GetComponent<BJ_deckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();
    }

    private void HitClicked()
    {
        throw new NotImplementedException();
    }

    private void StayClicked()
    {
        throw new NotImplementedException();
    }
}
