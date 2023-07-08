using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceBehaviour : MonoBehaviour
{
    [SerializeField] Sprite[] facesSprites;
    [SerializeField]Image imageSprite;
    const float delayTime = 0.1f;

    public void Play()
    {
        StartCoroutine(PlayCoroutine());
    }

    IEnumerator PlayCoroutine()
    {
        imageSprite.sprite = null;
        yield return new WaitForSeconds(delayTime);
        int number = Random.Range(0, facesSprites.Length);
        imageSprite.sprite = facesSprites[number];
    }
}
