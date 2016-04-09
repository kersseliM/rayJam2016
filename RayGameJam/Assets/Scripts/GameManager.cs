using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject GGPanel;
    public Text GGText;

    private bool[] playerDead = new bool[2];

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        playerDead[0] = false;
        playerDead[1] = false;
    }

    public bool GetPlayerDead(int id) { return playerDead[id]; }
    public void SetPlayerDead(int id)
    {
        if(id == 0 && !playerDead[1])
        {
            playerDead[0] = true;
            DeadEvent(id);
        }
        if (id == 1 && !playerDead[0])
        {
            playerDead[1] = true;
            DeadEvent(id);
        }
    }
    private void DeadEvent(int id)
    {
        GGPanel.SetActive(true);
        GGText.text = "Player  " + (id + 1) + "  Got  Rekt";
    }
}
