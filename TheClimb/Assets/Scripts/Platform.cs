using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Platform_Type
{
    Basic,
    Break,
    Spring,
    Fade
}

public class Platform : MonoBehaviour
{
    public Platform_Type type;

    public float fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);

        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            //Debug.Log("PLAT IN VIEW");
        }
        else
        {
            if (viewPos.y < 0)
            {
                Debug.Log("PLAT IS GONE");
                gameObject.SetActive(false);
            }
        }
    }

    public void PlatformAction()
    {
        if(type == Platform_Type.Break)
        {
            Destroy(gameObject);
        } else if(type == Platform_Type.Fade)
        {
            StartCoroutine(FadePlatformCo());
        }
    }

    IEnumerator FadePlatformCo()
    {
        float fadeTimer = fadeTime;

        while(fadeTimer > 0)
        {


            GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, Mathf.MoveTowards(GetComponent<Renderer>().material.color.a, 0f, fadeTimer));


            fadeTimer -= Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
        
    }
}
