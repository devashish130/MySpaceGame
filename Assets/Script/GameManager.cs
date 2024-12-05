using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject enemyPrefab;
    public float minInstantiateValue;
    public float maxInstantiateValue;
    public float enemyDestoryTime = 10f;

    [Header("Particle effect")]
    public GameObject explosion;
    public GameObject MuzzleFlash;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InvokeRepeating("InstantiateEnemy", 1f, 2f);
    }


    void InstantiateEnemy()
    {
        Vector3 enemypos = new Vector3(Random.Range(minInstantiateValue, maxInstantiateValue), 10f);
        GameObject enemy = Instantiate(enemyPrefab, enemypos, Quaternion.Euler(0f,0f,180f));
        Destroy(enemy, enemyDestoryTime);


    }

   
}