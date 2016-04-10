using UnityEngine;
using System.Collections;

public class FallingXploFruit : MonoBehaviour
{
    public MeshRenderer myRend;
    public float lifeDistance = 1;
    public Vector3 maxPos;
    public Vector3 minPos;
    private float lifeCounter = 0;
    private bool isSet = false;
    private bool isLiving = false;
    private PoolLink myLink;
    private SphereCollider myCol;
    private Rigidbody myRB;

    new Transform transform;
    void Start()
    {
        if (!isSet)
        {
            transform = gameObject.transform;
            myLink = GetComponent<PoolLink>();
            myCol = GetComponent<SphereCollider>();
            myRB = GetComponent<Rigidbody>();
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
        transform.position = new Vector3(Random.Range(minPos.x,maxPos.x), Random.Range(minPos.y, maxPos.y), Random.Range(minPos.z, maxPos.z));
        lifeCounter = lifeDistance;
        Whatabled(true);
 //       myRB.AddForce((transform.forward + transform.up) * Random.Range(throwForce.x, throwForce.y), ForceMode.Impulse);
    }
    void Update()
    {
        if (isLiving)
        {
            lifeCounter -= Time.deltaTime;
            if (lifeCounter <= 0)
            {
                Deset();
            }
        }
    }
    void OnCollisionEnter(Collision colleisson)
    {
        if (colleisson.gameObject.tag == "Ground")
        {
            KickUpFleimHandly fleims = (KickUpFleimHandly)AdditionalPool.instance.GetObject((int)additionalPool.kickFleims).MainScript;
            fleims.Set(transform.position);
            EffetcHandly spawnEff = (EffetcHandly)AdditionalPool.instance.GetObject((int)additionalPool.effXploNorm).MainScript;
            spawnEff.Set(transform.position);
            EffetcHandly spawnEff2 = (EffetcHandly)AdditionalPool.instance.GetObject((int)additionalPool.effSmoke).MainScript;
            spawnEff2.Set(transform.position);
            AudioCreatureHandly spawnAudio = (AudioCreatureHandly)AdditionalPool.instance.GetObject((int)additionalPool.audioXplo).MainScript;
            spawnAudio.Set(transform.position);
            Deset();
        }
    }
    public void Deset()
    {
        Whatabled(false);
        myRB.velocity = Vector3.zero;
        myLink.ReturnToPool();
    }
    private void Whatabled(bool state)
    {
        myRend.enabled = state;
        myCol.enabled = state;
        isLiving = state;
        if (state)
        {
            myRB.isKinematic = false;
        }
        else
        {
            myRB.isKinematic = true;
        }
    }
}