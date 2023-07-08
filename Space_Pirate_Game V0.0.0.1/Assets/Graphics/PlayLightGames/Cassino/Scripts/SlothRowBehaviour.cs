using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothRowBehaviour : MonoBehaviour
{
    bool isSpining = false;
    [SerializeField]float startPositionY;
    [SerializeField]float endPositionY;
    [SerializeField]float decreaseAmountY = 0.2f;
    [SerializeField] float rpmDecrease = 1f;
    [SerializeField] float maxRpm = 10f;
    float currentRpm;
    string rowValue;

    public bool IsSpining { get { return isSpining; } }


    public void StartRotate(float timeStart, float timeEnd, int index)
    {
        if (isSpining) return;
        isSpining = true;
        //transform.position= new Vector2(transform.position.x,yValue);
        float time = Random.Range(timeStart, timeEnd);
        time *= (index);
        currentRpm = maxRpm;
        //Invoke("Init", time);
    }

    void Init()
    {
        isSpining = true;
        currentRpm = maxRpm;

    }

    private void Update()
    {
        if (isSpining)
        {
            if (transform.position.y <= endPositionY)
                transform.position = new Vector2(transform.position.x, startPositionY);
            transform.position = new Vector2(transform.position.x, transform.position.y - decreaseAmountY * Time.deltaTime * currentRpm);
            currentRpm -= Time.deltaTime * rpmDecrease;
            currentRpm = Mathf.Clamp(currentRpm, 0, maxRpm);
            if (currentRpm == 0)
                isSpining = false;
        }

      
    }
    

}
