using UnityEngine;
using System.Collections;

public class RotateBF : MonoBehaviour
{
    public Vector3 speed;
    public Vector3 max;
    public Vector3 min;

    private Vector3 curAngle;
    private Vector3 cur;
    new Transform transform;

    void Start()
    {
        transform = gameObject.transform;
    }

    void Update()
    {
        cur = new Vector3(speed.x*Time.deltaTime, speed.y * Time.deltaTime, speed.z * Time.deltaTime);
        curAngle += cur;
        if(speed.x > 0 && curAngle.x >= max.x)
        {
            cur.x += (max.x - curAngle.x) * 2;
            curAngle.x += (max.x - curAngle.x) * 2;
            speed.x *= -1;
        }
        else if (speed.x < 0 && curAngle.x <= min.x)
        {
            cur.x += (min.x - curAngle.x) * 2;
            curAngle.x += (min.x - curAngle.x) * 2;
            speed.x *= -1;
        }

        if (speed.y > 0 && curAngle.y >= max.y)
        {
            cur.y += (max.y - curAngle.y) * 2;
            curAngle.y += (max.y - curAngle.y) * 2;
            speed.y *= -1;
        }
        else if (speed.y < 0 && curAngle.y <= min.y)
        {
            cur.y += (min.y - curAngle.y) * 2;
            curAngle.y += (min.y - curAngle.y) * 2;
            speed.y *= -1;
        }

        if (speed.z > 0 && curAngle.z >= max.z)
        {
            cur.z += (max.z - curAngle.z) * 2;
            curAngle.z += (max.z - curAngle.z) * 2;
            speed.z *= -1;
        }
        else if (speed.z < 0 && curAngle.z <= min.z)
        {
            cur.z += (min.z - curAngle.z) * 2;
            curAngle.z += (min.z - curAngle.z) * 2;
            speed.z *= -1;
        }

        transform.Rotate(cur);
    }
}