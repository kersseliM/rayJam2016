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
    public float z = -5;

    public float intesitymultiplier;

   en_Fruits[]  oikeaLottoRivi;

    public KeyCode stop, start;
    RotateObject ActiveSlot;

[HideInInspector]  public int lm_UnActive = 10;
    public LayerMask lm_ActiveSlot;

    public static SlottiMaster Instance;

    bool Touched;

    public Transform[] SlotSpawnPoints;

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
      //  SLOTS[1].ReStartReel();
        oikeaLottoRivi = new en_Fruits[SLOTS.Length];


        Invoke("SetAutoSpin",10);
    }

    bool autoSpin;

    void SetAutoSpin()
    {
        if (Touched == false)
        {
            InvokeRepeating("Spindin", 2, 4f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
           
            if (autoSpin)
            CancelInvoke("Spindin");
            Touched = true;
            Spindin();
        }
    }


    void Spindin()
    {

        autoSpin = true;
        if (!endOfSpin)
        {
            StopActiveReel();
        }
        else
        {
            RestartSlots();
        }
    }
    public void StopActiveReel()
    {
            ActiveSlot.StopReel();
    }


    public void TrueStopReel()
    {
        ActiveSlot.trueStop();
    }

    public void IntenseMore()
    {

        intesitymultiplier = intesitymultiplier * 4f;
    }

    public void RestartSlots()
    {
        endOfSpin = false;
        count = 0;
        Touched = false;

        intesitymultiplier = 4;
        foreach (RotateObject r in SLOTS)
        {
            r.ReStartReel();
            r.speed = Random.Range(intesitymultiplier, 40);
            
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
            Invoke("i", 0.2f);
            // ActiveSlot = SLOTS[count];


            if (count >= SLOTS.Length)
            {

                CancelInvoke("i");
                endOfSpin = true;
         
                CalculateSpinResults();
            }
        }

    }




   public void CalculateSpinResults()
    {
        print("Oikea lotto rivi on " + oikeaLottoRivi[0] + oikeaLottoRivi[1] + oikeaLottoRivi[2]);

        int FirstSlot = (int)oikeaLottoRivi[0];
        int SecondSlot = (int)oikeaLottoRivi[1];
        int ThirdSlot = (int)oikeaLottoRivi[2];

        int standartAmount =1;
        int kaksX_amount =5;
        int jackPotAmount =15;

        EventManager.instance.AddEvent(FirstSlot, standartAmount);
        EventManager.instance.AddEvent(SecondSlot, standartAmount);
        EventManager.instance.AddEvent(ThirdSlot, standartAmount);
       
        if (FirstSlot == SecondSlot && ThirdSlot != FirstSlot)
        {
            print("KaksiOikein");
            MusicBox.instance.InstantiateSoundObject(MusicBox.instance.TwoWin);
            EventManager.instance.AddEvent(FirstSlot, kaksX_amount);  
        }

        if (FirstSlot == ThirdSlot && SecondSlot != FirstSlot)
        {
            print("KaksiOikein");
            MusicBox.instance.InstantiateSoundObject(MusicBox.instance.TwoWin);
            EventManager.instance.AddEvent(FirstSlot, kaksX_amount);
        }

        if (ThirdSlot == SecondSlot && SecondSlot != FirstSlot)
        {
            print("KaksiOikein");
            MusicBox.instance.InstantiateSoundObject(MusicBox.instance.TwoWin);
            EventManager.instance.AddEvent(FirstSlot, kaksX_amount);
        }


        if (FirstSlot == SecondSlot && SecondSlot!= ThirdSlot)
        {
            print("JÄTII POTTI"); MusicBox.instance.InstantiateSoundObject(MusicBox.instance.kolmeOIkein);
            EventManager.instance.AddEvent(FirstSlot, jackPotAmount);
        }

        if (FirstSlot == 8 && SecondSlot ==8 && ThirdSlot == 8)
        {
            print("Super JÄfsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdTII POTTI"); MusicBox.instance.InstantiateSoundObject(MusicBox.instance.jattipotti);
 
         //   EventManager.instance.AddEvent(FirstSlot, jackPotAmount);
        }

    }

public   Vector3 getSpawnPosition()
    {

        if (count < SLOTS.Length)
        {
            return SlotSpawnPoints[count].position;
        }
        else
        {
            return SlotSpawnPoints[2].position;
        }
    }

    bool endOfSpin;
    void i()
    {

        ActiveSlot = SLOTS[count];
        ActiveSlot.ActiveMe();
    }
}
