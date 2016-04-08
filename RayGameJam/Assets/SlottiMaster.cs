using UnityEngine;
using System.Collections;

public class SlottiMaster : MonoBehaviour
{
    public ArrowOfFortune arrowOfFortune;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void rayCastArrow()
    {
        arrowOfFortune.RayCast();
    }

}
