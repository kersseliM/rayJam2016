using UnityEngine;
using System.Collections;

public class SlottiSoundKusetyus : MonoBehaviour {

    public float itime;
	// Use this for initialization
	void Start () {
        Invoke("i", itime);
	}


    void i()
    {
        GetComponent<AudioSource>().Play();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
