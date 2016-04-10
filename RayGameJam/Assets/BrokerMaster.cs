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


    public void TRANSFORM(int id)
    {
        pelaajienHaamut[id].TransForm();
    }

    public void UN___TRANSFORM(int id)
    {
        pelaajienHaamut[id].UnTransform();
    }
    // Update is called once per frame

}
