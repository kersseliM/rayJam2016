using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PoolLink : MonoBehaviour
{
    public MonoBehaviour mainScript;
    public UnityEvent onInstantiate;
    private int myId = -1;
    private bool isSet = false;

    public void OnInstantiate(int id)
    {
        myId = id;
        if (onInstantiate != null)
        {
            onInstantiate.Invoke();
        }
    }
    public void ReturnToPool() { MainPool.instance.ReturnObject(myId, this); }
    public MonoBehaviour MainScript { get { return mainScript; } }
}
