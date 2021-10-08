using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum collectableType
    {
        star,
        coin,
        redGem,
        greenGem,
        blueGem,
        purpleGem,
        cyanGem,
        yellowGem
    }
    public collectableType druh;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
         if(druh == collectableType.coin)
            {
                GameManager.instance.CoinCollected();
            }
         else if(druh == collectableType.star)
            {
                GameManager.instance.StarCollected();
            }
         else
            {
                other.gameObject.GetComponent<CubeColors>().EnableColorSide(druh);
                InGameUIPanel.instance.EnableGemImg(druh);
            }           
            Destroy(gameObject);
        }
    }
}
