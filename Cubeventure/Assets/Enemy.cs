using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    public float movementSpeed;
    private Vector3 targetPosition;
    private int wavepointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        targetPosition = waypoints[wavepointIndex].position;
        transform.position = targetPosition;

    }
    void Update()
    {
        Vector3 dir = targetPosition - transform.position;
        Debug.Log(dir);
        transform.rotation = Quaternion.LookRotation(dir);
        transform.Translate(dir.normalized * movementSpeed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex == waypoints.Length-1)
        {
            wavepointIndex = 0;
        }
        else
            wavepointIndex++;

        targetPosition = waypoints[wavepointIndex].position;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(gameObject.tag))
        {
            Debug.Log("Slime squished");
            Destroy(gameObject);
        }
    }



}
