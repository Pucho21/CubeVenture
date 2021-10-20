using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorEnum;

public class LaserTrigger : MonoBehaviour
{
    public ColorType druhLaserTriggeru;

    // Start is called before the first frame update
    void Awake()
    {
        SetTriggerType();
    }

    public void SetTriggerType()
    {
        Color farba;
        if (druhLaserTriggeru == ColorType.Red)
        {
            farba = Color.red;
        }
        else if (druhLaserTriggeru == ColorType.Blue)
        {
            farba = Color.blue;
        }
        else if (druhLaserTriggeru == ColorType.Green)
        {
            farba = Color.green;
        }
        else if (druhLaserTriggeru == ColorType.Cyan)
        {
            farba = Color.cyan;
        }
        else if (druhLaserTriggeru == ColorType.Magenta)
        {
            farba = Color.magenta;
        }
        else
        {
            farba = Color.yellow;
        }
        transform.GetChild(1).GetComponent<MeshRenderer>().material.color = farba;
    }
    public void OnEnable()
    {
        Debug.Log("TriggerEnabled " + druhLaserTriggeru.ToString());
    }

    public void OnDisable()
    {
        Debug.Log("TriggerDisabled " + druhLaserTriggeru.ToString());
    }
}
