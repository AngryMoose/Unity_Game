using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int currency;
    [SerializeField] private Text doubloonText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        doubloonText.text = "Doubloons:" + PlayerManager.instance.currency;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Currency"))
        {
            Destroy(collision.gameObject);
            currency++;
            PlayerManager.instance.currency = currency;
            doubloonText.text = "Doubloons:" + PlayerManager.instance.currency;
            collectionSoundEffect.Play();
        }
    }

}
