using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUpdator : MonoBehaviour
{
    public Text[] scoreTxt;

    void Start()
    {
        UpdateScore();
    }
    public void UpdateScore()
    {
        for (int i = 0; i < scoreTxt.Length; i++)
        {
            scoreTxt[i].text = "" + ScoreHolder.instance.GetScore(i);
        }
    }
}
