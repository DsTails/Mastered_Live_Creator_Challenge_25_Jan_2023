using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Power Up", menuName = "Scriptable Objects/Power Ups/Teleport")]
public class TeleportPower : PowerUp
{
    public override void ActivatePowerUp(PlayerController player)
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 60f, player.transform.position.z);
        Camera.main.transform.position = player.transform.position + Camera.main.gameObject.GetComponent<CameraFollow>().offset;
    }
}
