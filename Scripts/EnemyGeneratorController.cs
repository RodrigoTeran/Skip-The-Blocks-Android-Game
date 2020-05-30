using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{

    public GameObject prefab;
    public float generatortimer = 5f;

    bool YN = false;

    // Update is called once per frame
    void Start()
    {
        if (YN)
        {
            InvokeRepeating("CreateEnemy", 0f, generatortimer);
        }
    }

    public void Cancel()
    {
        CancelInvoke();
    }

    void CreateEnemy()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    public void StartMoving()
    {
        YN = true;
        Start();
    }
}
