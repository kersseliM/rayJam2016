using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour
{
    public float speed = 1;
    new Transform transform;
    void Start()
    {
        transform = gameObject.transform;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
