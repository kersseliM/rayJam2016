using UnityEngine;
using System.Collections;

public class Jekku : MonoBehaviour {

    public float todenn= 4;
    SpriteRenderer sp;
    bool check;
	// Use this for initialization
	void Start () {

        sp = GetComponent<SpriteRenderer>();
        Invoke("c", Random.Range(0, 20));
	}


    void c()
    {
        check = true;
        if (Random.Range(0, 2000) >= todenn)
        {
            sp.enabled = true;
        }
    }


}
