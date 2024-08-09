using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform spawnPoint;
    private bool isRespawning = false;


    public void StartRespawn()
    {
        if(!isRespawning)
        {
            StartCoroutine(RespawnEnemy());
        }
    }
    IEnumerator RespawnEnemy()
    {
        isRespawning = true;
        yield return new WaitForSeconds(1f);
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        isRespawning = false;
    }
}
