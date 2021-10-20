using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnPoint : MonoBehaviour
{
    public  GameObject playerGO;
    public CinemachineVirtualCamera vcam;
    public PlayerHatHandler hatHandler;



    void Awake()
    {
        StartCoroutine(SpawnPlayer());
    }


    IEnumerator SpawnPlayer()
    {
        Animator portalAnim = GetComponent<Animator>();
        portalAnim.Play("FadeInPortal");        
        yield return new WaitForSeconds(1f);

        GameObject player = Instantiate(playerGO, transform.position, Quaternion.identity);

        Vector3 cameraPos = vcam.GetComponentInChildren<CinemachineTransposer>().m_FollowOffset + player.transform.position;
        vcam.Follow = player.transform;
        vcam.LookAt = player.transform;
        vcam.ForceCameraPosition(cameraPos, Quaternion.Euler(51.34f, 0, 0));        

        hatHandler.SetPlayerTransform(player.transform);

        portalAnim.Play("FadeOutPortal");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    

   
}
