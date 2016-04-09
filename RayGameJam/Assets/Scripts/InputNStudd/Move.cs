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
            dTapTimer[0] += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.W))
            {
                TapDown(0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                Tap(0);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                TapUp(0);
            }
        }
        if (!GameManager.instance.GetPlayerDead(1))
        {
            dTapTimer[1] += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                TapDown(1);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Tap(1);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                TapUp(1);
            }
        }
    }
    private void TapDown(int id)
    {
        if (dTapTimer[id] < dTapTime)
        {
            playerRotator[id].speed *= -1;
        }
        dTapTimer[id] = 0;

        storedPRotSpeed[id] = playerRotator[id].speed;
        playerRotator[id].speed = Vector3.zero;

    }
    private void Tap(int id)
    {
        playerRB[id].AddForce(playerTransform[id].forward * power * Time.deltaTime, ForceMode.Impulse);
    }
    private void TapUp(int id)
    {
        playerRotator[id].speed = storedPRotSpeed[id];
    }
}
