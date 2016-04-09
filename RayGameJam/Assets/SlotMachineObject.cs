using UnityEngine;
using System.Collections;

public class SlotMachineObject : MonoBehaviour
{
   SimpleRotate rotareObject;


   public en_TypeOfObject MYTYPE;
        

    public en_Fruits MyID;
    Vector3 originalScale;
    // Use this for initialization
    void Awake()
    {
        if (transform.childCount > 0)
        {
            rotareObject = transform.GetChild(0).gameObject.GetComponent<SimpleRotate>();
        }
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateMe()
    {

        if(rotareObject != null)
      rotareObject.enabled = true;
      transform.localScale = originalScale * 1.4f;






        print(MyID);
    }


    public void DeActiveMe()
    {
        transform.localScale = originalScale;
        if (rotareObject != null)
        rotareObject.enabled = false;
    }

}
