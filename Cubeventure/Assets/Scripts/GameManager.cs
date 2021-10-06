using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int starsCount;
    [HideInInspector]public int collectedStarsCount = 0;

    [Space]
    public int coinsCount;
    [HideInInspector] public int collectedCoinsCount = 0;

    private void Awake()
    {
        instance = this;
    }



    public void CoinCollected()
    {
        collectedCoinsCount++;
        InGameUIPanel.instance.UpdateCoinsCountText();
    }

    public void StarCollected()
    {
        collectedStarsCount++;
        InGameUIPanel.instance.UpdateStarsCountText();
    }
}
