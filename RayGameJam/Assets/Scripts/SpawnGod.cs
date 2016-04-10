using UnityEngine;
using System.Collections;

public class SpawnGod : MonoBehaviour
{
    public Transform[] spawnPoint;
    private bool turn = false;
    private int prev = 0;
    public void Spawn(en_Fruits id)
    {
        int curPoint = NewPointId();
        switch (id)
        {
            case en_Fruits.Appelsiini:
                XploFruit xploFruit = (XploFruit)MainPool.instance.GetObject((int)id).MainScript;
                xploFruit.Set(spawnPoint[curPoint].eulerAngles, spawnPoint[curPoint].position);
                break;
            case en_Fruits.Rypaleet:
                KillerFruit killerFruit = (KillerFruit)MainPool.instance.GetObject((int)id).MainScript;
                killerFruit.Set(spawnPoint[curPoint].eulerAngles, spawnPoint[curPoint].position);
                break;
            case en_Fruits.Paaryna:
                GrowFruit growFruit = (GrowFruit)MainPool.instance.GetObject((int)id).MainScript;
                growFruit.Set(spawnPoint[curPoint].eulerAngles, spawnPoint[curPoint].position);
                break;
            case en_Fruits.Luumukiisseli:
                FallingXploFruit fallXploFruit = (FallingXploFruit)MainPool.instance.GetObject((int)id).MainScript;
                fallXploFruit.Set(spawnPoint[curPoint].eulerAngles, spawnPoint[curPoint].position);
                break;
            case en_Fruits.Banaani:
                SpinKickFruit spinKickFruit = (SpinKickFruit)MainPool.instance.GetObject((int)id).MainScript;
                spinKickFruit.Set(spawnPoint[curPoint].eulerAngles, spawnPoint[curPoint].position);
                break;
            case en_Fruits.Kirsikka:
                LowSpinnerFruit spinLowFruit = (LowSpinnerFruit)MainPool.instance.GetObject((int)id).MainScript;
                spinLowFruit.Set(spawnPoint[curPoint].eulerAngles, spawnPoint[curPoint].position);
                break;
            default:
                BasicFruit newFruit = (BasicFruit)MainPool.instance.GetObject((int)id).MainScript;
                newFruit.Set(spawnPoint[curPoint].eulerAngles, spawnPoint[curPoint].position);
                break;
        }
        EffetcHandly spawnEff = (EffetcHandly)AdditionalPool.instance.GetObject((int)additionalPool.effCanFire).MainScript;
        spawnEff.Set(spawnPoint[curPoint].position);
        EffetcHandly spawnEff2 = (EffetcHandly)AdditionalPool.instance.GetObject((int)additionalPool.effSparks).MainScript;
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
