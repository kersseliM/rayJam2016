using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{

    public Vector3 rotate;
    public float speed = 5;

    public KeyCode stop, start;
    bool isSpinning = true;


    SlotMachineObject[] myfruSits;
    public bool isActive = true;


    // Use this for initialization
    void Start()

    {
        Transform t = transform.FindChild("Fruits");

        print(t);
        myfruSits = new SlotMachineObject[t.childCount];

        for (int i = 0; i < t.childCount; i++)
        {
            myfruSits[i] = t.GetChild(i).gameObject.GetComponent<SlotMachineObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {

            if (isSpinning == true)
                RotateObjecy(speed);
    }

    public void StopReel()
    {
        SlottiMaster.Instance.rayCastArrow();
        
      //  isSpinning = false;
    }

    public void trueStop()
    {
        print("trueds");
        isSpinning = false;

    }


  public  void ActiveMe()
    {
        isActive = true;
        isSpinning = true;
        print(gameObject.name);
        foreach (SlotMachineObject t in myfruSits)
        {
            t.gameObject.layer = 9;
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
