using UnityEngine;
using System.Collections;

public class SpawnGod : MonoBehaviour
{
    public float spawnTime = 1;
    public Transform myRotationTrans;
    private float spawnTimer = 0;
    new Transform transform;
    void Start()
    {
        transform = gameObject.transform;
        spawnTimer = spawnTime;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Spawn();
            spawnTimer = spawnTime + spawnTimer;
        }
    }
    private void Spawn()
    {
        BasicFruit newFruit = (BasicFruit)MainPool.instance.GetObject(Random.Range(0,5)).MainScript;
        newFruit.Set(myRotationTrans.localEulerAngles, transform.position);
    }
}
