using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public Rigidbody[] playerRB;
    public Transform[] playerTransform;
    public float power;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRB[0].AddForce(playerTransform[0].forward * power * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRB[1].AddForce(playerTransform[1].forward * power * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
