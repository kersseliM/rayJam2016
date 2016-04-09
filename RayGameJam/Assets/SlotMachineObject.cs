using UnityEngine;
using System.Collections;

public class SlotMachineObject : MonoBehaviour
{
    SimpleRotate rotareObject;
    public en_Fruits MyID;
    Vector3 originalScale;
    bool once;
    BoxCollider bc;
    SphereCollider sc;
    Vector3 startLocalPosition;
    Transform parent;
    // Use this for initialization
    void Awake()
    {
        if (transform.childCount > 0)
        {
            rotareObject = transform.GetChild(0).gameObject.GetComponent<SimpleRotate>();
            transform.GetChild(0).gameObject.layer = 8;
        }
        bc = GetComponent<BoxCollider>();
        // bc.size = bc.size * 2;
        originalScale = transform.localScale;
        sc = GetComponent<SphereCollider>();

    }


    public void timeToSpinForReal()
    {


        sc.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Start()
    {
        startLocalPosition = transform.localPosition;
        parent = transform.parent;
    }

    public void ActivateMe()
    {

        if (!once)
        {
     
            /*  Vector3 pos = transform.position;
              pos.y = SlottiMaster.Instance.y;
              pos.z = SlottiMaster.Instance.z;
             * */
            //    transform.position = pos;

            if (rotareObject != null)
                rotareObject.enabled = true;
            transform.localScale = originalScale * 4f;

           
            transform.parent = null;
            transform.position = SlottiMaster.Instance.getSpawnPosition();

        

       //     gameObject.layer = 10;
          

            SlottiMaster.Instance.RegisterMe(MyID);
            once = true;

            gameObject.transform.GetChild(0).gameObject.layer = 4;

            Invoke("i", 0.4f);
        }
    }

    void i()
    {
        gameObject.layer = 4;
    }


    public void DeActiveMe()
    {

        sc.enabled = false;
        transform.parent = parent;
        gameObject.layer = 9;
        once = false;
        transform.localScale = originalScale;
        transform.localPosition = startLocalPosition;
        if (rotareObject != null)
            rotareObject.enabled = false;
    }

}
