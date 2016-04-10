using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{

    public Vector3 rotate;
    public float speed = 5;

    public KeyCode stop, start;
    bool isSpinning = true;

    public int MySlotID;

    SlotMachineObject[] myfruSits;
    public bool isActive = true;


    // Use this for initialization
    void Start()

    {
        Transform t = transform.FindChild("Fruits");
        myfruSits = new SlotMachineObject[t.childCount];

        for (int i = 0; i < t.childCount; i++)
        {
            myfruSits[i] = t.GetChild(i).gameObject.GetComponent<SlotMachineObject>();
        }
        ORIGINALSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {

            if (isSpinning == true)
                RotateObjecy(speed);
    }

    float ORIGINALSpeed;
    public void StopReel()
    {
        speed = ORIGINALSpeed * 0.5f;
        Invoke("RAYARROW", 0.5f);
        
      //  isSpinning = false;
    }


    void RAYARROW()
    {
        SlottiMaster.Instance.rayCastArrow();
    }

    public void trueStop()
    {
        MusicBox.instance.slotReels[MySlotID].enabled = false;
        isSpinning = false;

    }


    public void DeActibeFruits()
    {


        foreach (SlotMachineObject t in myfruSits)
        {
            t.DeActiveMe();
        }

    }

  public  void ActiveMe()
    {
        isActive = true;
        isSpinning = true;
        MusicBox.instance.slotReels[MySlotID].enabled = false;
        print(gameObject.name);
        foreach (SlotMachineObject t in myfruSits)
        {
            t.gameObject.layer = 9;
            t.timeToSpinForReal();
        }

    }


    public void HIT()
    {
        isActive = false;
        gameObject.layer = SlottiMaster.Instance.lm_UnActive;
        foreach (Transform t in transform)
        {
            t.gameObject.layer = 10;
        }
    }

    public void RotateObjecy(float speed)
    {
        transform.Rotate(rotate * Time.deltaTime * speed);
    }


    public void ReStartReel()
    {
        print("Restart");
        isSpinning = true;

        gameObject.layer = SlottiMaster.Instance.lm_UnActive;

        foreach (SlotMachineObject dk in myfruSits)
        {
            dk.DeActiveMe();
        }

        foreach (SlotMachineObject t in myfruSits)
        {
            t.gameObject.layer = 9;
        }
    }


}
