using UnityEngine;
using System.Collections;

public class SlottiMaster : MonoBehaviour
{
    public ArrowOfFortune arrowOfFortune;

    public RotateObject[] SLOTS;// 


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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(stop))
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
        
        ActiveSlot.StopReel();
        arrowOfFortune.RayCast();
    }

    public void RestartSlots()
    {
        foreach (RotateObject r in SLOTS)
        {
            r.ReStartReel();
        }


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


    public void SlotHit()
    {




    }
}
