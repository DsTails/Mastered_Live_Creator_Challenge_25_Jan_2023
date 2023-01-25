using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject gameOverMenu;

    public bool isAlive;
    float startDist = 0;
    public float currentDistance;

    public TextMeshProUGUI distanceText;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        //Decide whether to dontdestroyonload

        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        isAlive = false;
        gameOverMenu.SetActive(true);
    }

    

    private void FixedUpdate()
    {
        currentDistance = FindObjectOfType<PlayerController>().GetComponent<Rigidbody>().velocity.y > 0 ?  0 + FindObjectOfType<PlayerController>().transform.position.y : currentDistance;
        distanceText.text = currentDistance.ToString("000m");
    }
}
