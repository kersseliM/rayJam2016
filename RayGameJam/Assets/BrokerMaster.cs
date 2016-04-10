using UnityEngine;
using System.Collections;

public class BrokerMaster : MonoBehaviour
{
    

  public  MeneRikki[] pelaajienHaamut;

    void Start()
    {
        
        
    }

    public void Broke(int id)
    {
        MusicBox.instance.setIntesity();
        pelaajienHaamut[id].BrokeMe();
        SlottiMaster.Instance.IntenseMore();

    }
    // Update is called once per frame
    void Update()
    {

    }
}
