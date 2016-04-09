using UnityEngine;
using System.Collections;

public class FleimsHanfly : MonoBehaviour
{
    public MeshRenderer myRend;
    public float growSpeed;
    public float maxSize;
    private bool isSet = false;
    private bool isLiving = false;
    private AdditionalPoolLink myLink;
    private SphereCollider myCol;
    private Rigidbody myRB;

    new Transform transform;
    void Start()
    {
        if (!isSet)
        {
            transform = gameObject.transform;
            myLink = GetComponent<AdditionalPoolLink>();
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