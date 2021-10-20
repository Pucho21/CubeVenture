using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [Space]
    [Header("Coins")]
    [SerializeField] GameObject starGO;

    [Space]
    [Header("Coins")]
    [SerializeField] GameObject coinGO;
    [Space]
    [SerializeField] GameObject redGemGO;
    [SerializeField] GameObject greenGemGO;
    [SerializeField] GameObject blueGemGO;
    [SerializeField] GameObject cyanGemGO;
    [SerializeField] GameObject magentaGemGO;
    [SerializeField] GameObject yellowGemGO;
    

    

    // Start is called before the first frame update
    void Start()
    {
        SpawnStars();
        SpawnCoins();
        SpawnGems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnGems()
    {
        int randomIndex = Random.Range(0, transform.GetChild(2).transform.childCount);
        Vector3 spawnPoint = transform.GetChild(2).transform.GetChild(randomIndex).position;
        Instantiate(redGemGO, spawnPoint, Quaternion.identity);

         randomIndex = Random.Range(0, transform.GetChild(3).transform.childCount);
         spawnPoint = transform.GetChild(3).transform.GetChild(randomIndex).position;
        Instantiate(greenGemGO, spawnPoint, Quaternion.identity);

         randomIndex = Random.Range(0, transform.GetChild(4).transform.childCount);
         spawnPoint = transform.GetChild(4).transform.GetChild(randomIndex).position;
        Instantiate(blueGemGO, spawnPoint, Quaternion.identity);

         randomIndex = Random.Range(0, transform.GetChild(5).transform.childCount);
         spawnPoint = transform.GetChild(5).transform.GetChild(randomIndex).position;
        Instantiate(cyanGemGO, spawnPoint, Quaternion.identity);

         randomIndex = Random.Range(0, transform.GetChild(6).transform.childCount);
         spawnPoint = transform.GetChild(6).transform.GetChild(randomIndex).position;
        Instantiate(magentaGemGO, spawnPoint, Quaternion.identity);

         randomIndex = Random.Range(0, transform.GetChild(7).transform.childCount);
         spawnPoint = transform.GetChild(7).transform.GetChild(randomIndex).position;
        Instantiate(yellowGemGO, spawnPoint, Quaternion.identity);
    }

    void SpawnCoins()
    {        
        List<int> indexArray = new List<int>();
        int coinsChildCount = transform.GetChild(1).transform.childCount;

        if (coinsChildCount < GameManager.instance.coinsCount)
        {
            Debug.LogWarning("SPAWN VIAC COINOV AKO JE SPAWNPOINTOV -> RETURN BEZ SPAWNU");
            return;
        }
            int randIndex;
        for(int i=0;i< GameManager.instance.coinsCount; i++)
        {
            randIndex = Random.RandomRange(0, coinsChildCount);

            while (indexArray.Contains(randIndex))
            {
                randIndex = Random.RandomRange(0, coinsChildCount);
            }

            indexArray.Add(randIndex);
        }
        for(int i=0;i<indexArray.Count;i++)
        {
            Vector3 spawnPoint = transform.GetChild(1).transform.GetChild(indexArray[i]).position;
            Instantiate(coinGO, spawnPoint, Quaternion.identity);
        }        
    }

    void SpawnStars()
    {
        List<int> indexArray = new List<int>();
        int coinsChildCount = transform.GetChild(0).transform.childCount;

        if (coinsChildCount < GameManager.instance.starsCount)
        {
            Debug.LogWarning("SPAWN VIAC STARS AKO JE SPAWNPOINTOV -> RETURN BEZ SPAWNU");
            return;
        }
        int randIndex;
        for (int i = 0; i < GameManager.instance.starsCount; i++)
        {
            randIndex = Random.RandomRange(0, coinsChildCount);

            while (indexArray.Contains(randIndex))
            {
                randIndex = Random.RandomRange(0, coinsChildCount);
            }

            indexArray.Add(randIndex);
        }
        for (int i = 0; i < indexArray.Count; i++)
        {
            Vector3 spawnPoint = transform.GetChild(0).transform.GetChild(indexArray[i]).position;
            Instantiate(starGO, spawnPoint, Quaternion.identity);
        }
    }
}
