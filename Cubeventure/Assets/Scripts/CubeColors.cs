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
            redCubeSide.GetComponent<BoxCollider>().enabled = true;
            redCubeSide.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (gemType == Collectable.collectableType.greenGem)
        {
            greenCubeSide.GetComponent<BoxCollider>().enabled = true;
            greenCubeSide.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (gemType == Collectable.collectableType.blueGem)
        {
            blueCubeSide.GetComponent<BoxCollider>().enabled = true;
            blueCubeSide.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (gemType == Collectable.collectableType.cyanGem)
        {
            cyanCubeSide.GetComponent<BoxCollider>().enabled = true;
            cyanCubeSide.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        else if (gemType == Collectable.collectableType.purpleGem)
        {
            magentaCubeSide.GetComponent<BoxCollider>().enabled = true;
            magentaCubeSide.GetComponent<MeshRenderer>().material.color = Color.magenta;
        }
        else if (gemType == Collectable.collectableType.yellowGem)
        {
            yellowCubeSide.GetComponent<BoxCollider>().enabled = true;
            yellowCubeSide.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }
}
