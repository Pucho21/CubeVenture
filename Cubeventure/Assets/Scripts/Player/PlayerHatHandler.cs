using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHatHandler : MonoBehaviour
{
    public GameObject player;


    // Update is called once per frame
    private void Awake()
    {
        SpawnSelectedHat();
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 2.25f, player.transform.position.z);
    }

    void SpawnSelectedHat()
    {
        if (UserInfoHolder.instance != null) 
        {
            string hatID = UserInfoHolder.instance.hatID;        
            GameObject hatGO = Resources.Load<GameObject>("Hats/" + hatID);
            GameObject spawnedHat = Instantiate(hatGO, transform.position, transform.rotation, transform);
            player.GetComponent<RollCube>().SetHatAnimator(spawnedHat.GetComponent<Animator>());
        }
        else
            Debug.Log("Nespawnujem HAT NEMAM ID");
    }
    
}
