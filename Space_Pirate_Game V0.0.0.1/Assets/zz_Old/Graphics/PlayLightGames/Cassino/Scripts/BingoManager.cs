using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BingoManager : MonoBehaviour
{
    List<int> numerosGerados = new List<int>();
    [SerializeField]Text bolaTexto;
    [SerializeField]CartelaBingoBehaviour[] cartelas;

    void GerarNumero()
    {
        List<int> possibleNumbers = new List<int>();
        for (int i = 1; i < 100; i++) possibleNumbers.Add(i);
        for (int i = 1; i < numerosGerados.Count; i++) possibleNumbers.Remove(numerosGerados[i]);
        if (possibleNumbers.Count == 0) return;
        int numero = possibleNumbers[Random.Range(0,possibleNumbers.Count)];
        bolaTexto.text = numero.ToString();
        numerosGerados.Add(numero);

        for (int i=0; i<cartelas.Length; i++)
        {
            cartelas[i].ApplyNumberHit(numero);
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            GerarNumero();
    }

}
