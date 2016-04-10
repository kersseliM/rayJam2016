using UnityEngine;
using System.Collections;

public class SceneTransitionEffect : MonoBehaviour
{
    public GameObject oneImage;
     float spawnRate = 0.05f;
     int howMany = 20;
    int count;

    float screenHeight;
    float screenWidht;

    public bool fadeOut;
   
    void Awake()
    {
        if(fadeOut)
        {
            return;
        }
        
        screenHeight = Screen.height;
        screenWidht = Screen.width;

     Invoke("StartLerp",5);
    }

    public void StartLerp()
    {
        a();
    }

    void a()
    {
        Vector3 pos = new Vector3(0, 0, 0); ;
        pos.x = Random.Range(0, screenWidht);
        pos.y = Random.Range(0, screenHeight);

        GameObject g = (GameObject)Instantiate(oneImage, pos, Quaternion.identity);
        g.GetComponent<RectTransform>().SetParent(transform);
        count++;
        if (count < howMany)
        {
            Invoke("a", spawnRate);
        }
    }
}
