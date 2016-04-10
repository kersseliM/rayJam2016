using UnityEngine;
using System.Collections;

public class MeneRikki : MonoBehaviour
{

    public GameObject eiRikkiOleva;
   Transform[] palaset;
   GameObject ssj;

    // Use this for initialization
    void Start()
    {
        palaset = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            palaset[i] = transform.GetChild(i);
        }
        ssj = eiRikkiOleva.transform.FindChild("ssj_hiukset").gameObject;

    }


    public void TransForm()
    {

        ssj.gameObject.SetActive(true);
    }

    public void UnTransform()
    {
        ssj.gameObject.SetActive(false);

    }
    public void BrokeMe()
    {

        eiRikkiOleva.SetActive (false);
        Destroy(eiRikkiOleva);

        foreach(Transform t in palaset)
        {
            t.gameObject.SetActive(true);
        }


    }

}
