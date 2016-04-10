using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour
{

    public static MusicBox instance;

    public AudioSource[] slotReels;


    public GameObject TwoWin;
    public GameObject SLOTLOCK;
    public GameObject kolmeOIkein;

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

    }

    public void InstantiateSoundObject(GameObject soundOnsd)
    {
        Instantiate(soundOnsd, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {

    }



    public GameObject jattipotti;
}
