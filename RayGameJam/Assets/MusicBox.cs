using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour
{

    public static MusicBox instance;

    public AudioSource[] slotReels;


    public GameObject TwoWin;
    public GameObject SLOTLOCK;
    public GameObject kolmeOIkein;
    float originalPitch;

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
    }
    // Use this for initialization
    void Start()
    {
        print("Start");
        originalPitch = GetComponent<AudioSource>().pitch;
    }

    public void InstantiateSoundObject(GameObject soundOnsd)
    {
        Instantiate(soundOnsd, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setIntesity()
    {

        GetComponent<AudioSource>().pitch += 0.1f;

        foreach (AudioSource ac in slotReels)
        {

            ac.pitch+= 0.1f;
        }

    }



    public GameObject jattipotti;
}
