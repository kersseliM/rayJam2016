using UnityEngine;
using System.Collections;

public class SpawnGod : MonoBehaviour
{
    public Transform[] spawnPoint;
    private bool turn = false;
    private int prev = 0;
    public void Spawn(int id)
    {
        int curPoint = NewPointId();
        switch (id)
        {
            case 0:
                XploFruit xploFruit = (XploFruit)MainPool.instance.GetObject(id).MainScript;
                xploFruit.Set(spawnPoint[curPoint].eulerAngles, spawnPoint[curPoint].position);
                break;
            case 2:
                KillerFruit killerFruit = (KillerFruit)MainPool.instance.GetObject(id).MainScript;
                killerFruit.Set(spawnPoint[curPoint].eulerAngles, spawnPoint[curPoint].position);
                break;
            default:
                BasicFruit newFruit = (BasicFruit)MainPool.instance.GetObject(id).MainScript;
                newFruit.Set(spawnPoint[curPoint].eulerAngles, spawnPoint[curPoint].position);
                break;
        }
        EffetcHandly spawnEff2 = (EffetcHandly)AdditionalPool.instance.GetObject((int)additionalPool.effSmoke).MainScript;
        spawnEff2.Set(spawnPoint[curPoint].position);
        AudioCreatureHandly spawnAudio = (AudioCreatureHandly)AdditionalPool.instance.GetObject((int)additionalPool.audioCannon).MainScript;
        spawnAudio.Set(spawnPoint[curPoint].position);
    }
    private int NewPointId()
    {
        int pointy = Random.Range(0, spawnPoint.Length);
        if (pointy == prev)
        {
            pointy = NewPointId();
        }
        prev = pointy;
        return pointy;
    }
}
