using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColors : MonoBehaviour
{

    [SerializeField] private GameObject redCubeSide;
    [SerializeField] private GameObject greenCubeSide;
    [SerializeField] private GameObject blueCubeSide;
    [SerializeField] private GameObject cyanCubeSide;
    [SerializeField] private GameObject magentaCubeSide;
    [SerializeField] private GameObject yellowCubeSide;





    public void EnableColorSide(Collectable.collectableType gemType)
    {
        if(gemType == Collectable.collectableType.redGem)
        {
            redCubeSide.SetActive(true);
        }
        else if (gemType == Collectable.collectableType.greenGem)
        {
            greenCubeSide.SetActive(true);
        }
        else if (gemType == Collectable.collectableType.blueGem)
        {
            blueCubeSide.SetActive(true);
        }
        else if (gemType == Collectable.collectableType.cyanGem)
        {
            cyanCubeSide.SetActive(true);
        }
        else if (gemType == Collectable.collectableType.purpleGem)
        {
            magentaCubeSide.SetActive(true);
        }
        else if (gemType == Collectable.collectableType.yellowGem)
        {
            yellowCubeSide.SetActive(true);
        }
    }
}
