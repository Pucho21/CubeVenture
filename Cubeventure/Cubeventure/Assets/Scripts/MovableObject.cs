using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public int speed = 300;
    bool isMoving = false;

    [Space]
    public LayerMask collisionLayer;
    public float raycastRange;
              
    

    public bool SlideInDirection(Vector3 direction)
    {
        if (CanRollInDirection(direction) && !isMoving)
        {
            StartCoroutine(Roll(direction));
            return true;
        }
        else
            return false;

    }


    IEnumerator Roll(Vector3 direction)
    {
        isMoving = true;

        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction + Vector3.down;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (remainingAngle > 0)
        {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        RoundCubePosition();
        isMoving = false;

    }

    void RoundCubePosition()
    {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
    }

    bool CanRollInDirection(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position,.5f, direction, out hit, raycastRange, collisionLayer))
        {
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject == gameObject)
                return true;
            else
                return false;
        }
        else
        {
            return true;
        }
    }



}
