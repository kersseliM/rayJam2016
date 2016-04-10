using UnityEngine;
using System.Collections;

public class Jekku : MonoBehaviour {

    public float todenn= 4;
    SpriteRenderer sp;
    bool check;
    public Animator sdlsdka;
    bool once;
	// Use this for initialization
	void Start () {

        sp = GetComponent<SpriteRenderer>();
        Invoke("c", Random.Range(0, 20));
	}


    void c()
    {
        check = true;
        if (Random.Range(0, 500) >= todenn)
        {
            sdlsdka.enabled = true;
            sp.enabled = true;
        }
    }


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Delete))
        {
            if (!once)
            {
                sdlsdka.enabled = true;
                sp.enabled = true;
                once = true;
            }

        }


    }


}
