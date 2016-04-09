using UnityEngine;
using System.Collections;

public class FallDeath : MonoBehaviour
{
    void OnCollisionEnter(Collision colleisson)
    {
        if (colleisson.gameObject.tag == "Player")
        {
            print(colleisson.gameObject.name);
            colleisson.gameObject.GetComponent<PlayerGuy>().Kill();
        }
    }
}
