using UnityEngine;
using System.Collections;

public class KickUpFleimHandly : MonoBehaviour
{
    public MeshRenderer myRend;
    public float growSpeed;
    public float maxSize;
    public float upPower;
    public float dirPower;
    private bool isSet = false;
    private bool isLiving = false;
    private AdditionalPoolLink myLink;
    private SphereCollider myCol;

    new Transform transform;
    void Start()
    {
        if (!isSet)
        {
            transform = gameObject.transform;
            myLink = GetComponent<AdditionalPoolLink>();
            myCol = GetComponent<SphereCollider>();
            Whatabled(false);
            isSet = true;
        }
    }
    public void OnInstantiate()
    {
        Start();
    }
    public void Set(Vector3 pos)
    {
        transform.position = pos;
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        Whatabled(true);
    }
    void Update()
    {
        if (isLiving)
        {
            transform.localScale += new Vector3(growSpeed * Time.deltaTime, growSpeed * Time.deltaTime, growSpeed * Time.deltaTime);
            if (transform.localScale.x >= maxSize)
            {
                Deset();
            }
        }
    }
    void OnTriggerEnter(Collider colleisson)
    {
        if (colleisson.gameObject.tag == "Player")
        {
            colleisson.gameObject.GetComponent<Rigidbody>().AddForce(((transform.position - colleisson.gameObject.transform.position) * dirPower) + (transform.up * upPower), ForceMode.Impulse);
            EffetcHandly spawnEff2 = (EffetcHandly)AdditionalPool.instance.GetObject((int)additionalPool.effSmoke).MainScript;
            spawnEff2.Set(colleisson.gameObject.transform.position);
            AudioCreatureHandly spawnAudio = (AudioCreatureHandly)AdditionalPool.instance.GetObject((int)additionalPool.audioPCol).MainScript;
            spawnAudio.Set(transform.position);
        }
    }
    public void Deset()
    {
        Whatabled(false);
        myLink.ReturnToPool();
    }
    private void Whatabled(bool state)
    {
        myRend.enabled = state;
        myCol.enabled = state;
        isLiving = state;
    }
}