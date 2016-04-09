using UnityEngine;
using System.Collections;

public class KillerFruit : MonoBehaviour
{
    public MeshRenderer myRend;
    public float lifeDistance = 1;
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
        print("kollideed");
        if (colleisson.gameObject.tag == "Player")
        {
            print("kollideed player");
            print(colleisson.gameObject.name);
            colleisson.gameObject.GetComponent<PlayerGuy>().Kill();
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
        myMove.enabled = state;
        isLiving = state;
    }
}
