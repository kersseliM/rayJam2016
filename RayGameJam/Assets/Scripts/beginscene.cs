using UnityEngine;
using System.Collections;

public class beginscene : MonoBehaviour
{
    public static beginscene instance;
    void Awake()
    {

        if (instance != null && instance != this)
        {
            Invoke("D", 3f);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    void D()
    {
        Application.Quit();
    }
}
