using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI endText;

    private void OnEnable()
    {
        GetComponent<Animator>().Play("GameOverScroll");
        SetGameOverText();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SetGameOverText()
    {
        endText.text = "You travelled " + GameManager.instance.currentDistance.ToString("000m") + "!";
    }
    
}
