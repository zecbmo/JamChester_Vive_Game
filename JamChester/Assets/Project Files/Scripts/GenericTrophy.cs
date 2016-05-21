using UnityEngine;
using System.Collections;

public enum TrophyType {NONE, T_1, T_2, T_3, T_4, T_5, T_6, T_7, T_8, T_9, T_10};


public class GenericTrophy : SteamVR_InteractableObject
{
    [Header("Trophy Stuff")]
    //Type and wheter the tasks for trophy completed
    public TrophyType type = TrophyType.T_1;
    private bool completed_ = false;
    
    //Managing Trophy State
    private enum TrophyState {IN_TRAY, ON_FLOOR, IN_SLOT, ACTIVE, COMPLETED};
    private TrophyState state_;
    private TrophyState prev_state_;


    //collidier managers
    private bool in_tray_ = false;
    private bool in_slot_ = false;


    //timer 
    private bool timer_start_ = false;
    private float on_floor_counter_ = 0;
    public float on_floor_max_time = 5; //how long the throphy can be on the floor before loosing

    protected override void Start()
    {
        base.Start();
      
    }

    public bool IsCompleted()
    {
        return completed_;
    }
    
    private void UpdateState()
    {
        if (IsGrabbed())
        {
            state_ = TrophyState.ACTIVE;
        }
        else if (in_tray_)
        {
            state_ = TrophyState.IN_TRAY;
        }
        else if (in_slot_ && completed_)
        {
            state_ = TrophyState.COMPLETED;
        }
        else if (in_slot_)
        {
            state_ = TrophyState.IN_SLOT;
        }        
        else
        {
            state_ = TrophyState.ON_FLOOR;
        }
    }

    void StateManager()
    {
        switch (state_)
        {
            case TrophyState.ACTIVE:
                break;
            case TrophyState.IN_SLOT:
                break;
            case TrophyState.IN_TRAY:
                break;
            case TrophyState.COMPLETED:
                isGrabbable = false;
                break;
            case TrophyState.ON_FLOOR:
                OnFloorStateHelper();
                OnFloorCounter();
                break;

        }

        prev_state_ = state_;
    }
    private void OnFloorStateHelper()
    {
        if (prev_state_ != TrophyState.ON_FLOOR)
        {
            timer_start_ = true; //indicates exact time/tick that the state changes to the floor
        }
        else
        {
            timer_start_ = false;
        }
    }

    //will control the win state... if it is on the floor for too long 
    void OnFloorCounter()
    {
        if (timer_start_) //called once 
        {
            on_floor_counter_ = 0;    
        }

        if (on_floor_counter_ > on_floor_max_time)
        {
            Globals.game_state = GameState.LOST;
        }

        on_floor_counter_ += Time.deltaTime;
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        StateManager();
       
    }

    protected override void Update()
    {
        UpdateState();
        print(on_floor_counter_);

    }

    void OnTriggerEnter(Collider coll)
    {
        //if collidiing with tray set the state
        if(coll.tag == "TRAY" && !IsGrabbed())
        {
            in_tray_ = true;
        }


        if (coll.tag == "SLOT" && !IsGrabbed())
        {
            in_slot_ = true;
        }
    }
    
}
