using UnityEngine;
using System.Collections;

public class ArrowOfFortune : MonoBehaviour
{

    public Transform spawnPoint;
    float rayLenght = 30;
    BoxCollider bc;
    
    Camera ac;



    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        // RayCast();
    }

    public bool RayCast()
    {

        Ray ray = new Ray(spawnPoint.position, transform.right);
        RaycastHit rayhit;
        Debug.DrawRay(ray.origin, ray.direction * rayLenght, Color.magenta, 20);

        if (Physics.Raycast(ray, out rayhit, rayLenght, SlottiMaster.Instance.lm_ActiveSlot))
        {

            rayhit.collider.gameObject.GetComponent<SlotMachineObject>().ActivateMe();
                SlottiMaster.Instance.TrueStopReel();

            return true;
        }


        return false;
    }

}
