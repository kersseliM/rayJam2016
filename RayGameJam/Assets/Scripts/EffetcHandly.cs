using UnityEngine;
using System.Collections;

public class EffetcHandly : MonoBehaviour
{
    private bool isSet = false;
    private bool isLiving = false;
    private AdditionalPoolLink myLink;
    public ParticleSystem myEff;

    new Transform transform;
    void Start()
    {
        if (!isSet)
        {
            transform = gameObject.transform;
            myLink = GetComponent<AdditionalPoolLink>();
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
        myEff.Play();
    }
    void Update()
    {
        if (isLiving)
        {
            if (!myEff.isPlaying)
            {
                Deset();
            }
        }
    }
    public void Deset()
    {
        myEff.Stop();
        Whatabled(false);
        myLink.ReturnToPool();
    }
    private void Whatabled(bool state)
    {
        isLiving = state;
    }
}
