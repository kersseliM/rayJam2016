﻿using UnityEngine;
using System.Collections;

public class SSJFruit : MonoBehaviour
{
    public MeshRenderer myRend;
    public float lifeDistance = 1;
    public float duration;
    public GameObject mySSJ;
    private float lifeCounter = 0;
    private bool isSet = false;
    private bool isLiving = false;
    private PoolLink myLink;
    private SphereCollider myCol;
    private MoveForward myMove;
    new Transform transform;
    void Start()
    {
        if (!isSet)
        {
            transform = gameObject.transform;
            myLink = GetComponent<PoolLink>();
            myCol = GetComponent<SphereCollider>();
            myMove = GetComponent<MoveForward>();
            Whatabled(false);
            isSet = true;
        }
    }
    public void OnInstantiate()
    {
        Start();
    }
    public void Set(Vector3 eulers, Vector3 pos)
    {
        transform.localEulerAngles = eulers;
        transform.position = pos;
        lifeCounter = lifeDistance;
        Whatabled(true);
    }
    void Update()
    {
        if (isLiving)
        {
            lifeCounter -= Time.deltaTime * myMove.speed;
            if (lifeCounter <= 0)
            {
                Deset();
            }
        }
    }
    void OnCollisionEnter(Collision colleisson)
    {
        if (colleisson.gameObject.tag == "Player")
        {
            colleisson.gameObject.GetComponent<PlayerGuy>().SetSSJ(true, duration);
            EffetcHandly spawnEff = (EffetcHandly)AdditionalPool.instance.GetObject((int)additionalPool.effSmoke).MainScript;
            spawnEff.Set(transform.position);
            AudioCreatureHandly spawnAudio = (AudioCreatureHandly)AdditionalPool.instance.GetObject((int)additionalPool.audioVictory1).MainScript;
            spawnAudio.Set(transform.position);
            Deset();
        }
    }

    public void Deset()
    {
        Whatabled(false);
        myLink.ReturnToPool();
    }
    private void Whatabled(bool state)
    {
        mySSJ.SetActive(state);
        myRend.enabled = state;
        myCol.enabled = state;
        myMove.enabled = state;
        isLiving = state;
    }
}

