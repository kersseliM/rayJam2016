using UnityEngine;
using System.Collections;

public class PlayerGuy : MonoBehaviour
{
    public int myId;

    void Start()
    {

    }

    void Update()
    {

    }
    public void Kill()
    {
        GameManager.instance.SetPlayerDead(myId);
    }
}
