using UnityEngine;
using System.Collections;

public enum TrophyType {NONE, T_1, T_2, T_3, T_4, T_5, T_6, T_7, T_8, T_9, T_10};
public enum TrophyColour {GOLD, SILVER, BRONZE };

public class GenericTrophy : SteamVR_InteractableObject
{
    [Header("Trophy Stuff")]
    //Type and wheter the tasks for trophy completed
    public TrophyType type = TrophyType.T_1;
    
    private bool completed_ = true;
    
    //Managing Trophy State
    private enum TrophyState {IN_TRAY, ON_FLOOR, IN_SLOT, ACTIVE, BROKEN, COMPLETED};
    private TrophyState state_;
    private TrophyState prev_state_;


    //collidier managers
    private bool in_tray_ = false;
    private bool in_slot_ = false;


    //timer 
    private bool timer_start_ = false;
    private float on_floor_counter_ = 0;
    public float on_floor_max_time = 5; //how long the throphy can be on the floor before loosing

    //cleaner 
    public CleanerType cleaner_type = CleanerType.NONE;
    public int number_of_sprays_to_clean = 3;
    private int spray_count = 0;


    //Rags for ragging
    public RagType rag_type = RagType.NONE;
    public float seconds_to_clean_with_rag = 2;
    private float rag_counter = 0;
    private bool rag_timer_start = false;
    private bool polished_with_rag = false;

    //base selector
    public enum BaseType { SQUARE, TRIANGLE, CIRCLE};
    public BaseType base_type = BaseType.SQUARE;
    private GameObject Base;

    //child protector...doesdnt get completed before the child updates
    protected bool child_completed = true; //change to true if not inhertited from 

    //colours that the trophy can be set to
    public Texture Gold;
    public Texture Bronze;
    public Texture Silver;

    public TrophyColour trophy_colour = TrophyColour.GOLD;

    //bad code
    private bool do_once = true;



    protected override void Start()
    {
        base.Start();
        SelectBase();
        SetColour();

    }
    public virtual void ChildStartFunctions()
    {
        //overide in childe
    }
    void SetColour()
    {
        switch (trophy_colour)
        {
            case TrophyColour.GOLD: //change texture here
                break;
            case TrophyColour.SILVER:
                break;
            case TrophyColour.BRONZE:
                break;

        }

    }
    void SelectBase()
    {
        switch (base_type)
        {
            case BaseType.SQUARE:
                Base = this.transform.Find("Square Base").gameObject;
                Base.SetActive(true);
                break;
            case BaseType.TRIANGLE:
                Base = this.transform.Find("Triangle Base").gameObject;
                Base.SetActive(true);
                break;
            case BaseType.CIRCLE:
                Base = this.transform.Find("Circle Base").gameObject;
                Base.SetActive(true);
                break;
        }

    }
    public bool IsCompleted()
    {
        if (rag_type != RagType.NONE)
        {
            return false;
        }
        if (!child_completed)
        {
            return false;
        }
        if (cleaner_type != CleanerType.NONE)
        {
            return false; 
        }

        completed_ = true;
        return true; 
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
            case TrophyState.BROKEN:
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

    //will control the win state... if it is on the floor for too long 
    void RagCounter()
    {
        if (rag_timer_start) //called once 
        {
            rag_counter += Time.deltaTime;
        }

        if (rag_counter > seconds_to_clean_with_rag)
        {
            polished_with_rag = true;
        }


    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        StateManager();
        RagCounter();
    }

    protected override void Update()
    {
        UpdateState();
       // print("Washed = :" + polished_with_rag + "  RagTimer: " + rag_counter);

        if (do_once)
        {
            ChildStartFunctions();
            do_once = false;
        }

        ChildUpdateFunctions();

    }

    public virtual void ChildUpdateFunctions()
    {
        //Put override functions for child class in here when inheriting
    }

    private void CheckAndSetCompletion()
    {
        if (cleaner_type != CleanerType.NONE)
        {
            return;
        }


        completed_ = true;
    }


    void OnTriggerEnter(Collider coll)
    {
        //if collidiing with tray set the state
        if (coll.tag == "TRAY" && !IsGrabbed())
        {
            in_tray_ = true;
        }


        if (coll.tag == "SLOT" && !IsGrabbed())
        {
            in_slot_ = true;
        }

        //manage actions when colliding with spray
        if (coll.tag == "SPRAY")
        {
            Spray script = coll.GetComponent<Spray>();
            if (script.cleaner_type == cleaner_type && !script.used)
            {
                //if correct spray
                script.used = true;
                spray_count++;
                if (spray_count == number_of_sprays_to_clean)
                {
                    cleaner_type = CleanerType.NONE;
                }
            }
            else
            {
                //if wrong spray...
            }
        }

        //rag collisions - start the timer
        if (coll.tag == "RAG TRIGGER")
        {
            Rag script = coll.GetComponent<Rag>();
            if (script.type == rag_type)
            {
                rag_timer_start = true;
            }
        }

    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "RAG TRIGGER")
        {

            if (rag_timer_start == true)
            {
                rag_timer_start = false;
                rag_counter = 0;
            }
        }
    }


}
