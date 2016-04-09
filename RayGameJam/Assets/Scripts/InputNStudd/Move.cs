using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public Rigidbody[] playerRB;
    public Transform[] playerTransform;
    public RotateAround[] playerRotator;
    public float power;
    public float dTapTime = 1;
    private float[] dTapTimer = new float[2];
    private Vector3[] storedPRotSpeed = new Vector3[2];

    void Start()
    {

    }
    void Update()
    {
        if (!GameManager.instance.GetPlayerDead(0))
        {
            if (Input.GetButtonUp("P1F"))
            {
                TapUp(0, 1);
            }
            if (Input.GetButtonUp("P1B"))
            {
                TapUp(0, -1);
            }
        }
        if (!GameManager.instance.GetPlayerDead(1))
        {
            if (Input.GetButtonUp("P2F"))
            {
                TapUp(1, 1);
            }
            if (Input.GetButtonUp("P2B"))
            {
                TapUp(1, -1);
            }
        }
        if (!GameManager.instance.GetPlayerDead(2))
        {
            if (Input.GetButtonUp("P3F"))
            {
                TapUp(2, 1);
            }
            if (Input.GetButtonUp("P3B"))
            {
                TapUp(2, -1);
            }
        }
        if (!GameManager.instance.GetPlayerDead(3))
        {
            if (Input.GetButtonUp("P4F"))
            {
                TapUp(3, 1);
            }
            if (Input.GetButtonUp("P4B"))
            {
                TapUp(3, -1);
            }
        }
    }
    private void TapUp(int id, int dir)
    {
        playerRB[id].AddForce(playerTransform[id].forward * power * Time.deltaTime * dir, ForceMode.Impulse);
    }
}
