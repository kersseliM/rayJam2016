using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour
{
    public Vector3 speed;
    private float multiply = 1;
    new Transform transform;

    void Start()
    {
        transform = gameObject.transform;
    }
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime * multiply);
    }
    public void SetMultiply(float value)
    {
        multiply = value;
    }
}
