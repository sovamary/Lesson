using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    static public Main solo;
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemyDefaultPadding = 1.5f;

    private BoundsChecker boundsChecker;

     void Awake()
    {
        solo = this;
        boundsChecker = GetComponent<BoundsChecker>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    public void SpawnEnemy()
    {
        int index = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[index]);


        float enemyPadding = enemyDefaultPadding;
        if(go.GetComponent<BoundsChecker>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsChecker>().radius);
        }
        Vector3 position = Vector3.zero;
        float xMin = -boundsChecker.cameraWidth + enemyPadding;
        float xMax = boundsChecker.cameraWidth - enemyPadding;
        position.x = Random.Range(xMin, xMax);
        position.y = boundsChecker.cameraHeight + enemyPadding;
        go.transform.position = position;
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
