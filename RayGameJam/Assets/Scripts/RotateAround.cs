using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour
{
    public Vector3 speed;
    new Transform transform;

    void Start()
    {
        transform = gameObject.transform;
    }
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}
