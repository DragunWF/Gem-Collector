using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gem Type", fileName = "New Gem Type")]
public class GemSO : ScriptableObject
{
    [SerializeField] Sprite[] gemSprites = new Sprite[7];
    [SerializeField] Color particleColor;

    public Sprite PickRandomShape()
    {
        return gemSprites[Random.Range(0, gemSprites.Length - 1)];
    }
}
