using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    public EventManager instance;
    public float eventDelay = 1f;
    public SpawnGod spawnGod;

    public float adderTime = 1f;
    private float adderTimer = 0;

    private float eventDelayCounter = 0;
    private Queue<int> eventQueue = new Queue<int>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        adderTimer = adderTime;
    }
    void Update()
    {

        adderTimer -= Time.deltaTime;
        if (adderTimer <= 0)
        {
            adderTimer = adderTime + adderTimer;
            int multiplyer = Random.Range(1, 3);
            AddEvent(Random.Range(0, 5), Random.Range(1, 10) * multiplyer);
        }


        if (eventQueue.Count > 0)
        {
            eventDelayCounter -= Time.deltaTime;
            if (eventDelayCounter <= 0)
            {
                ActivateEvent(eventQueue.Dequeue());
                if (eventQueue.Count > 0)
                {
                    eventDelayCounter = eventDelay;
                }
            }
        }
    }

    public void AddEvent(int id, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            eventQueue.Enqueue(id);
        }
    }

    private void ActivateEvent(int id)
    {
        switch (id)
        {
            case 0:
                spawnGod.Spawn(id);
                break;
            case 1:
                spawnGod.Spawn(id);
                break;
            case 2:
                spawnGod.Spawn(id);
                break;
            case 3:
                spawnGod.Spawn(id);
                break;
            case 4:
                spawnGod.Spawn(id);
                break;
            default:
                break;
        }
    }
}
