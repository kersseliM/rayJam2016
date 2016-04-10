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
        pelaajienHaamut[id].BrokeMe();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
