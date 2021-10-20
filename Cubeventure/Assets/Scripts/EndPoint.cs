using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    Animator portalAnim;
    void Awake()
    {
        portalAnim = GetComponent<Animator>();
        portalAnim.Play("PortalRotate");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            portalAnim.Play("FadeOutPortal");
            Debug.Log("zmiznutie hraca sem");
            GameManager.instance.EndGame();
            other.GetComponent<RollCube>().StopPlayerMovement();
        }
    }





}
