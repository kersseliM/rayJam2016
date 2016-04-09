using UnityEngine;
using System.Collections;



public struct kolmenRivi
{
  public  en_Fruits firstSlotID;
  public en_Fruits secondSlotID;
  public en_Fruits thirdSlotID;     
}

public class SlottiMaster : MonoBehaviour
{
    public ArrowOfFortune arrowOfFortune;

    public RotateObject[] SLOTS;// 

    public float y;

   en_Fruits[]  oikeaLottoRivi;

    public KeyCode stop, start;
    RotateObject ActiveSlot;

[HideInInspector]  public int lm_UnActive = 10;
    public LayerMask lm_ActiveSlot;

    public static SlottiMaster Instance;

    void Awake()
    {

        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }

    // Use this for initialization
    void Start()
    {
        ActiveSlot = SLOTS[0];
        oikeaLottoRivi = new en_Fruits[SLOTS.Length];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(stop))
        {
            StopActiveReel();
        }
        if (Input.GetKeyDown(start))
        {
            RestartSlots();
        }
    }

    public void StopActiveReel()
    {
        print("dd");
            ActiveSlot.StopReel();
    }


    public void TrueStopReel()
    {
        ActiveSlot.trueStop();
    }

    public void RestartSlots()
    {
        endOfSpin = false;
        count = 0;
       

        print("RestartSlots");
        foreach (RotateObject r in SLOTS)
        {
            r.ReStartReel();
        }

        ActiveSlot = SLOTS[0];
        ActiveSlot.ActiveMe();
    }

    public void rayCastArrow()
    {
        if (ActiveSlot.isActive == true)
        {

            if (arrowOfFortune.RayCast() == false)
            {
                ActiveSlot.RotateObjecy(3);
                print("false");
                Invoke("rayCastArrow", 0.02F);
            }
            else
            {
                ActiveSlot.HIT();
            }
        }
    }


    int count;

    public void SlotHit()
    {




    }

    internal void RegisterMe(en_Fruits MyID)
    {

        if (!endOfSpin)
        {

            oikeaLottoRivi[count] = MyID;

            count++;
            Invoke("i", 1);
            // ActiveSlot = SLOTS[count];


            if (count >= SLOTS.Length)
            {

                CancelInvoke("i");
                endOfSpin = true;
                print("Oikea lotto rivi on " + oikeaLottoRivi[0]+ oikeaLottoRivi[1]+ oikeaLottoRivi[2]);

            }
        }

    }


    bool endOfSpin;
    void i()
    {

        ActiveSlot = SLOTS[count];
        ActiveSlot.ActiveMe();
    }
}
