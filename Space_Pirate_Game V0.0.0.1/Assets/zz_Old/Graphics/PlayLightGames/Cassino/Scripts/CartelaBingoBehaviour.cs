using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CartelaBingoBehaviour : MonoBehaviour
{
    int[] numbers = new int[24];
    bool[] numbersHit = new bool[24];
    Text[] textsNumbers;

    private void Awake()
    {
        textsNumbers = GetComponentsInChildren<Text>();
        GenerateNumbers();
    }

    void GenerateNumbers()
    {
        List<int> possibleNumbers = new List<int>();
        for (int i=1; i<=99; i++) { possibleNumbers.Add(i); }

        for (int i=0; i<numbers.Length; i++)
        {
            int number = possibleNumbers[Random.Range(0,possibleNumbers.Count)];
            numbers[i] = number;
            possibleNumbers.Remove(number);
        }

        numbers = (from ns in numbers orderby ns ascending select ns).ToArray();
        for (int i=0; i<numbers.Length; i++)
        {
            textsNumbers[i].text = numbers[i].ToString();
        }
    }

    public void ApplyNumberHit(int generateNumber)
    {
        for (int i=0; i<numbers.Length; i++)
        {
            if (numbers[i].Equals(generateNumber))
            {
                numbersHit[i] = true;
                textsNumbers[i].text = "O";
                textsNumbers[i].color = Color.red;
            }
        }
    }

}
