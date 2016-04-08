using UnityEngine;
using System.Collections;

public class ArrowOfFortune : MonoBehaviour
{

    public Transform spawnPoint;
    float rayLenght = 3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // RayCast();
    }

   public void RayCast()
    {

        Ray ray = new Ray(spawnPoint.position, transform.right);
        RaycastHit rayhit;
        Debug.DrawRay(ray.origin, ray.direction * rayLenght,Color.magenta,20);

        if (Physics.Raycast(ray, out rayhit, rayLenght))
        {
            print(rayhit.collider.gameObject.name);
        }

    }

}
