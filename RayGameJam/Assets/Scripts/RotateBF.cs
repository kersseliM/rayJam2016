using UnityEngine;
using System.Collections;

public class RotateBF : MonoBehaviour
{
    public Vector3 speed;
    public Vector3 min;
    public Vector3 max;
    private Vector3 cur;
    private Vector3 dir;
    private Vector3 eulerChange;

    new Transform transform;

    void Start()
    {
        transform = gameObject.transform;
        dir = Vector3.one;
        cur = Vector3.zero;
    }
    
    void Update()
    {
        transform.Rotate(new Vector3(speed.x * dir.x * Time.deltaTime, speed.y * dir.y * Time.deltaTime, speed.z * dir.z * Time.deltaTime));
        cur = new Vector3(cur.x + speed.x * dir.x * Time.deltaTime, cur.y + speed.y * dir.y * Time.deltaTime, cur.z + speed.z * dir.z * Time.deltaTime);
        print(cur);

        if(cur.x >= max.x)
        {
            eulerChange.x = max.x - cur.x;
            cur.x -= eulerChange.x;
            dir.x *= -1;
        }
        else if(cur.x <= min.x)
        {
            eulerChange.x = min.x - cur.x;
            cur.x += eulerChange.x;
            dir.x *= -1;
        }

        if (cur.y >= max.y)
        {
            eulerChange.y = max.y - cur.y;
            cur.y -= eulerChange.y;
            dir.y *= -1;
        }
        else if (cur.y <= min.y)
        {
            eulerChange.y = min.y - cur.y;
            cur.y += eulerChange.y;
            dir.y *= -1;
        }

        if (cur.z >= max.z)
        {
            eulerChange.z = max.z - cur.z;
            cur.z -= eulerChange.z;
            dir.z *= -1;
        }
        else if (cur.z <= min.z)
        {
            eulerChange.z = min.z - cur.z;
            cur.z += eulerChange.z;
            dir.z *= -1;
        }

        if(eulerChange != Vector3.zero)
        {
            transform.localEulerAngles += eulerChange;
            eulerChange = Vector3.zero;
        }
    }
}
