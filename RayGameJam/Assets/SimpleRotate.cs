using UnityEngine;
using System.Collections;

public class SimpleRotate : MonoBehaviour
{
    public Vector3 rotate;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate * Time.deltaTime);
    }
}
