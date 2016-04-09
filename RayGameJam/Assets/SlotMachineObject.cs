using UnityEngine;
using System.Collections;

public class SlotMachineObject : MonoBehaviour
{
    SimpleRotate rotareObject;
    public en_Fruits MyID;
    Vector3 originalScale;
    bool once;
    BoxCollider bc;
    Vector3 startLocalPosition;
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
        startLocalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateMe()
    {

        if (!once)
        {

            Vector3 pos = transform.position;
            pos.y = SlottiMaster.Instance.y;
            pos.z = SlottiMaster.Instance.z;
            transform.position = pos;

            if (rotareObject != null)
                rotareObject.enabled = true;
            transform.localScale = originalScale * 1.4f;

            gameObject.layer = 10;

            SlottiMaster.Instance.RegisterMe(MyID);
            once = true;
        }
    }


    public void DeActiveMe()
    {
        gameObject.layer = 9;
        once = false;
        transform.localScale = originalScale;
        transform.localPosition = startLocalPosition;
        if (rotareObject != null)
            rotareObject.enabled = false;
    }

}
