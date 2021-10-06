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
            Debug.Log("Collected " + druh);
            Destroy(gameObject);
        }
    }
}
