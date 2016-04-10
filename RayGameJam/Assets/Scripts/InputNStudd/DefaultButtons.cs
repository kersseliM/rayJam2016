using UnityEngine;
using System.Collections;

public class DefaultButtons : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
    }


    private void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
