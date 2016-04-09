using UnityEngine;
using System.Collections;

public class SpawnGod : MonoBehaviour
{
    public Transform[] spawnPoint;
    private bool turn = false;
    private int prev = 0;
    public void Spawn(int id)
    {
        BasicFruit newFruit = (BasicFruit)MainPool.instance.GetObject(id).MainScript;
        int curPoint = NewPointId();
        newFruit.Set(spawnPoint[curPoint].eulerAngles, spawnPoint[curPoint].position);
        /*  if (turn)
          {
              newFruit.Set(spawnPoint[0].eulerAngles, spawnPoint[0].position);
              turn = false;
          }
          else
          {
              newFruit.Set(spawnPoint[1].eulerAngles, spawnPoint[1].position);
              turn = true;
          }*/
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
