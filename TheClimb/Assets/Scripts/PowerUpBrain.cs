using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBrain : MonoBehaviour
{
    public PowerUp usedPowerUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            usedPowerUp.ActivatePowerUp(other.GetComponent<PlayerController>());
            Destroy(this.gameObject);
        }
    }
}
