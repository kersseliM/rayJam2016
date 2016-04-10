using UnityEngine;
using System.Collections;

public class DontDestory : MonoBehaviour {


    public static DontDestory Instance;
    void Awake()
    {

        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }


	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
