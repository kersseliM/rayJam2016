using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{

    public Vector3 rotate;
    public float Speed = 5;

    public  KeyCode stop, start;
    bool isSpinning = true;

    bool isActive = true;
    public SlottiMaster slottiMaster;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            if (isSpinning == true)
                transform.Rotate(rotate * Time.deltaTime * Speed);

            if (Input.GetKeyDown(stop))
            {
                StopReel();
            }
            if (Input.GetKeyDown(start))
            {
                ReStartReel();
            }
        }
    }

  public  void StopReel()
    {
        slottiMaster.rayCastArrow();
        isSpinning = false;
    }


  public void ReStartReel()
  {
      isSpinning = true;
  }


}
