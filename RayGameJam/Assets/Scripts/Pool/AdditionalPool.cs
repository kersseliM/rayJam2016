using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdditionalPool : MonoBehaviour
{
    public static AdditionalPool instance;
    public GameObject[] poolObjects;
    private List<Stack<AdditionalPoolLink>> links = new List<Stack<AdditionalPoolLink>>();

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
        for (int i = 0; i < poolObjects.Length; i++)
        {
            links.Add(new Stack<AdditionalPoolLink>());
        }
    }

    public AdditionalPoolLink GetObject(int id)
    {
        if (links[id].Count <= 0)
        {
            GameObject newPoolObj = (GameObject)Instantiate(poolObjects[id], new Vector3(9000, 9000, 9000), Quaternion.identity);
            links[id].Push(newPoolObj.GetComponent<AdditionalPoolLink>());
            links[id].Peek().OnInstantiate(id);
        }
        return links[id].Pop();
    }
    public void ReturnObject(int id, AdditionalPoolLink obj)
    {
        obj.transform.position = new Vector3(9000, 9000, 9000);
        links[id].Push(obj);
    }
}

