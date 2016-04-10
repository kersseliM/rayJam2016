using UnityEngine;
using System.Collections;

public class ScoreHolder : MonoBehaviour
{
    public static ScoreHolder instance;
    private int[] scores = new int[4];
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = 0;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void AddScore(int playerId)
    {
        scores[playerId] += 1;
    }
    public int GetScore(int playerId)
    {
        if (scores[playerId] != null)
        {
            return scores[playerId];
        }
        else
        {
            return 0;
        }
    }
}
