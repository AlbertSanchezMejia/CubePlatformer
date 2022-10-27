using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Portals_Manager : MonoBehaviour
{
    #region Make it a Singleton
    public static Portals_Manager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] GameObject player_1;
    [SerializeField] GameObject player_2;

    public bool PlayersAreDeactivated()
    {
        return (player_1.activeInHierarchy == false || player_2.activeInHierarchy == false);
    }

    public void SpawnNewPlayer(Transform portalEntered, Transform portalToExit, Vector3 playerPosition)
    {
        float xPosDifference = portalEntered.position.x - playerPosition.x + 0.25f;
        float yPosDifference = portalEntered.position.y - playerPosition.y;

        Vector3 spawnPoint = portalToExit.position;
        spawnPoint.x -= xPosDifference;
        spawnPoint.y -= yPosDifference;

        GameObject newPlayer = DeactivatedPlayer();
        newPlayer.transform.localRotation = portalToExit.localRotation;
        newPlayer.transform.position = spawnPoint;
        newPlayer.SetActive(true);
    }

    GameObject DeactivatedPlayer()
    {
        if (player_1.activeInHierarchy == false)
        {
            return player_1;
        }
        else if (player_2.activeInHierarchy == false)
        {
            return player_2;
        }
        return null;
    }

}
