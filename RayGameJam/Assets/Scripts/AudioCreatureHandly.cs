using UnityEngine;
using System.Collections;

public class AudioCreatureHandly : MonoBehaviour
{
    private bool isSet = false;
    private bool isLiving = false;
    private AdditionalPoolLink myLink;
    private AudioSource myAudio;

    new Transform transform;
    void Start()
    {
        if (!isSet)
        {
            transform = gameObject.transform;
            myLink = GetComponent<AdditionalPoolLink>();
            myAudio = GetComponent<AudioSource>();
            Whatabled(false);
            isSet = true;
        }
    }
    public void OnInstantiate()
    {
        Start();
    }
    public void Set(Vector3 pos)
    {
        transform.position = pos;
        Whatabled(true);
        myAudio.Play();
    }
    void Update()
    {
        if (isLiving)
        {
            if (!myAudio.isPlaying)
            {
                Deset();
            }
        }
    }
    public void Deset()
    {
        Whatabled(false);
        myLink.ReturnToPool();
    }
    private void Whatabled(bool state)
    {
        isLiving = state;
        myAudio.enabled = state;
    }
}
