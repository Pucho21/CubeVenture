using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    
    public GameObject doorGO;
    public enum ColorType 
    {     
        Red,
        Blue,
        Yellow,
        Cyan,
        Purple,
        Green,
    }
    public ColorType doorColor;

    [Space]
    [Header("Čas ktorý zostanú dvere otvorené")]
    public bool isDoorTimed;
    public float openTime;
    float timeLeft;



    // Start is called before the first frame update
    void Start()
    {
        SetDoorColor();
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

    void SetDoorColor() {
        Color farba;
        if (doorColor == ColorType.Red) {
            farba = Color.red;
        } else if (doorColor == ColorType.Blue) {
            farba = Color.blue;
        } else if (doorColor == ColorType.Green) {
            farba = Color.green;
        } else if (doorColor == ColorType.Cyan) {
            farba = Color.cyan;
        } else if (doorColor == ColorType.Purple) {
            farba = Color.magenta;
        } else {
            farba = Color.yellow;
        }
        transform.tag = doorColor.ToString();
        transform.GetChild(0).GetComponent<MeshRenderer>().material.color = farba; // zmena farby btnu
        doorGO.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = farba; // zmena farby dveri

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.CompareTag(doorColor.ToString())) // ak slapne hrac
        {
            OpenDoor();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(doorColor.ToString())) // ak slapne hrac
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
