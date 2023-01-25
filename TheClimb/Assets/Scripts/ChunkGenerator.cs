using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    float initialYSpawn;
    public float spawnPosY;

    public float chunkSizeX;
    public float chunkSizeY;

    public GameObject chunks;

    public bool isContinuous;
    public int numberOfChunks;

    // Start is called before the first frame update
    void Start()
    {
        initialYSpawn = spawnPosY;

        if (!isContinuous)
        {
            for(int i = 0; i < numberOfChunks; i++)
            {
                GameObject platformChunk = Instantiate(chunks, new Vector3(0, spawnPosY, 0), Quaternion.identity);
                platformChunk.transform.SetParent(transform);

                if(platformChunk.transform.position.y != initialYSpawn)
                {
                    //Set to inactive to preserve performance
                    platformChunk.GetComponent<PlatformChunk>().platformsParent.gameObject.SetActive(false);
                }

                spawnPosY += chunkSizeY;
            }
        }
        else
        {
            StartCoroutine(GenerateChunks());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateChunks()
    {
        do
        {
            GameObject platformChunk = Instantiate(chunks, new Vector3(0, spawnPosY, 0), Quaternion.identity);
            platformChunk.transform.SetParent(transform);

            if (platformChunk.transform.position.y != initialYSpawn)
            {
                //Set to inactive to preserve performance
                platformChunk.GetComponent<PlatformChunk>().platformsParent.gameObject.SetActive(false);
            }

            spawnPosY += chunkSizeY;

            yield return new WaitForSeconds(1.5f);
        } while (GameManager.instance.isAlive);

        
    }
}
