using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChunk : MonoBehaviour
{
    //How many platforms will appear within the chunk
    public int platformNumber = 10;
    public Vector2 ChunkSize;

    public float powerUpChance;

    //Platform to be generated. Start off with the basic for now to test the function
    public GameObject platform;
    public GameObject powerUp;
    public GameObject enemy;

    public Transform platformsParent;

    BoxCollider chunkTrigger;

    // Start is called before the first frame update
    void Start()
    {
        chunkTrigger = GetComponent<BoxCollider>();
        chunkTrigger.size = new Vector3(ChunkSize.x + ChunkSize.x / 1.25f, ChunkSize.y + ChunkSize.y / 1.25f, 1);

        //GenerateChunkPlatforms();
        GeneratePlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(FindObjectOfType<PlayerController>().transform.position.x >= transform.position.x + (ChunkSize.x / 2) + 5f)
        {
            FindObjectOfType<PlayerController>().transform.position = new Vector3(transform.position.x + ((-ChunkSize.x) / 2) + .75f, FindObjectOfType<PlayerController>().transform.position.y, FindObjectOfType<PlayerController>().transform.position.z);
        } else if(FindObjectOfType<PlayerController>().transform.position.x <= transform.position.x + ((-ChunkSize.x) / 2) - 5f)
        {
            FindObjectOfType<PlayerController>().transform.position = new Vector3(transform.position.x + (ChunkSize.x / 2) -.75f, FindObjectOfType<PlayerController>().transform.position.y, FindObjectOfType<PlayerController>().transform.position.z);
        }
    }

    public void GenerateChunkPlatforms()
    {
        for(int i = 0; i < platformNumber; i++)
        {
            GameObject platformSpawned = Instantiate(platform, new Vector3(transform.position.x + Random.Range(-(ChunkSize.x / 2), ChunkSize.x / 2), transform.position.y + Random.Range(-(ChunkSize.y / 2), ChunkSize.y / 2), 0), Quaternion.identity);

            platformSpawned.GetComponent<Platform>().type = SetPlatformType(platformSpawned);

            platformSpawned.transform.SetParent(platformsParent);
        }
    }
    
    public void GeneratePlatforms()
    {
        float platformYSpawn = transform.position.y - ChunkSize.y / 2.0f;

        for(int i = 0; i < platformNumber; i++)
        {
            GameObject platformSpawned = Instantiate(platform, new Vector3(transform.position.x + Random.Range(-(ChunkSize.x / 2), ChunkSize.x / 2), platformYSpawn, 0), Quaternion.identity);

            //platformSpawned.GetComponent<Platform>().type = SetPlatformType(platformSpawned);

            platformSpawned.transform.SetParent(platformsParent);
            platformYSpawn += Random.Range(2.0f, 4.0f);

            //Check if a power up will spawn
            if (CheckPowerUpChance())
            {
                GameObject powerUpSpawned = Instantiate(powerUp, platformSpawned.transform.position + new Vector3(0, 3f, 0), Quaternion.identity);
                powerUpSpawned.transform.SetParent(platformsParent);
            }
        }

        int enemiesToSpawn = Random.Range(-5, 5);

        if(enemiesToSpawn > 0)
        {
            for(int i = 0; i < enemiesToSpawn; i++)
            {
                GameObject enemyToSpawn = Instantiate(enemy, new Vector3(transform.position.x + Random.Range(-(ChunkSize.x / 2), ChunkSize.x / 2), transform.position.y + Random.Range(-(ChunkSize.y / 2), ChunkSize.y / 2)), Quaternion.identity);
            }
        }
    }

    public bool CheckPowerUpChance()
    {
        float spawnChance = Random.Range(0.0f, 100.0f);
        return spawnChance < powerUpChance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            platformsParent.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            platformsParent.gameObject.SetActive(false);
        }
    }

    public Platform_Type SetPlatformType(GameObject platformToName)
    {
        float platformChance = Random.Range(0.0f, 100.0f);
        if(platformChance < 50)
        {
            platformToName.name = "Basic Platform";
            return Platform_Type.Basic;
            //Spawn a basic platform 50% of the time
        } else if(platformChance >= 50 && platformChance < 70)
        {
            platformToName.name = "Break Platform";

            //20% chance for break platform
            return Platform_Type.Break;
        } else if (platformChance >= 70 && platformChance < 90)
        {
            platformToName.name = "Fade Platform";

            return Platform_Type.Fade;
        }
        else
        {
            platformToName.name = "Spring Platform";

            return Platform_Type.Spring;
        }
    }

}
