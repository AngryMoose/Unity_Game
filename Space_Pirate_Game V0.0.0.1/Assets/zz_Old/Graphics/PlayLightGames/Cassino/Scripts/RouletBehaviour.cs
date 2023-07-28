using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletBehaviour : MonoBehaviour
{
    bool isSpining;
    float currentRpm;
    [SerializeField] float decreaseRpm = 0.1f;
    [SerializeField] float maxRpm = 25f;



    private void Update()
    {
        UpdateSpin();
    }

    public void Play_click()
    {
        SpinStart();
    }

    void SpinStart()
    {
        if (isSpining) return;

        isSpining = true;
        currentRpm = maxRpm;
        float randonAngle = Random.Range(0, 360);
        transform.Rotate(0,0,randonAngle);

    }

    void UpdateSpin()
    {
        if (!isSpining) return;
        transform.Rotate(0, 0, currentRpm);
        currentRpm -= Time.deltaTime * decreaseRpm;
        currentRpm = Mathf.Clamp(currentRpm, 0, maxRpm);
        if (currentRpm == 0)
            isSpining = false;

    }


}
