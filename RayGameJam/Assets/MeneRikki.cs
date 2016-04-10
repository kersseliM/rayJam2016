using UnityEngine;
using System.Collections;

public class MeneRikki : MonoBehaviour
{

    public GameObject eiRikkiOleva;
   Transform[] palaset;

    // Use this for initialization
    void Start()
    {
        palaset = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            palaset[i] = transform.GetChild(i);
        }

    }


    public void BrokeMe()
    {

        print(eiRikkiOleva);
        eiRikkiOleva.SetActive (false);
        Destroy(eiRikkiOleva);

        foreach(Transform t in palaset)
        {
            t.gameObject.SetActive(true);
        }


    }

}
