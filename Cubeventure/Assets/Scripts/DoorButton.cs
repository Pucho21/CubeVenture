using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Color doorColor;
    public GameObject doorGO;

    [Space]
    [Header("Čas ktorý zostanú dvere otvorené")]
    public bool isDoorTimed;
    public float openTime;
    float timeLeft;



    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<MeshRenderer>().material.color = doorColor; // zmena farby btnu
        doorGO.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = doorColor; // zmena farby dveri
    }

    // Update is called once per frame
    void Update()
    {
        if(isDoorTimed)
        {
            if (timeLeft > 0)
                timeLeft -= Time.deltaTime;
            else
                CloseDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) // ak slapne hrac
        {
            OpenDoor();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // ak slapne hrac
        {
            if(isDoorTimed)
                timeLeft = openTime;
        }
    }

    void OpenDoor()
    {
        if(isDoorTimed)
        {
            timeLeft = openTime;
            enabled = true;
            
        }
        doorGO.transform.GetChild(0).GetComponent<Animator>().Play("OpenDoor");
    }

    void CloseDoor()
    {
        enabled = false;
        doorGO.transform.GetChild(0).GetComponent<Animator>().Play("CloseDoor");
    }
}
