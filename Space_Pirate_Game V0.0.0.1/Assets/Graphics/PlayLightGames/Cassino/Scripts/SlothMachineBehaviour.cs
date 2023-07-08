using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothMachineBehaviour : MonoBehaviour
{
    [SerializeField]SlothRowBehaviour[] slots;
    [SerializeField] int maxBet = 300;
    [SerializeField] int betIncreaseValue = 20;
    [SerializeField] float timeStart, timeEnd;
    int currentBet;
    int currentCash = 1000;
    bool isAuto;
    public bool IsRotating { get { return CheckRotate(); } }

    public void Rotate()
    {
        if (currentCash <= 0) return;
        if (currentCash-currentBet <= 0) return;


        currentCash -= currentBet;
        for (int i = 0; i < slots.Length; i++)
            slots[i].StartRotate(timeStart, timeEnd, i);
    }

    public void IncreaseBet()
    {
        currentBet += betIncreaseValue;
        currentBet = Mathf.Clamp(currentBet,0,maxBet);
    }

    public void DecreaseBet()
    {
        currentBet -= betIncreaseValue;
        currentBet = Mathf.Clamp(currentBet, 0, maxBet);


    }

    public void Auto_click()
    {
        isAuto = !isAuto;
        StopCoroutine(AutoPlayCoroutine());
        if (isAuto)
            StartCoroutine(AutoPlayCoroutine());
    }

    public bool CheckRotate()
    {
        for (int i=0; i<slots.Length; i++)
        {
            if (slots[i].IsSpining)
                return true;
        }
        return false;
    }

    public void IncreaseCash(int cash)
    {
        currentCash += cash;
    }

    IEnumerator AutoPlayCoroutine()
    {
        if (!IsRotating)
        {
            Rotate();
        }
        yield return new WaitForSeconds(1f);
        if(isAuto)
            StartCoroutine(AutoPlayCoroutine());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Rotate();
        }
    }
}
