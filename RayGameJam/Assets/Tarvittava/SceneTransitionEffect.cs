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

     Invoke("StartLerp",2);
    }

    public void StartLerp()
    {
        a();
        Invoke("d", 2);
    }

    void d()
    {
        Application.LoadLevel(1);
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
