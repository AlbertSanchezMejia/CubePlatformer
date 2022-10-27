using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Collisions : MonoBehaviour
{
    [SerializeField] Transform otherPortal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_1") || other.CompareTag("Player_2"))
        {
            if (Portals_Manager.instance.PlayersAreDeactivated())
            {
                Portals_Manager.instance.SpawnNewPlayer(this.transform, otherPortal, other.gameObject.transform.position);
            }
        }
    }

}
