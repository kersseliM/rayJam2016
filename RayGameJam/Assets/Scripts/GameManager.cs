using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject GGPanel;
    public Text GGText;

    public BrokerMaster bmaster;
    private bool[] playerDead = new bool[4];

    void Awake()
    {
        if (instance == null)
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
        playerDead[id] = true;
        bmaster.Broke(id);
        byte livingCount = 0;
        int winnerId = 608;
        for (int i = 0; i < playerDead.Length; i++)
        {
            if (!playerDead[i])
            {
                livingCount++;
                winnerId = i;
            }
        }
        if (livingCount == 1)
        {
            DeadEvent(winnerId);
        }
    }
    private void DeadEvent(int id)
    {
        AudioCreatureHandly spawnAudio = (AudioCreatureHandly)AdditionalPool.instance.GetObject((int)additionalPool.audioVictory1).MainScript;
        spawnAudio.Set(transform.position);
        GGPanel.SetActive(true);
        GGText.text = "Player  " + (id + 1) + "  Rekted  'ém  All!";
    }
}
