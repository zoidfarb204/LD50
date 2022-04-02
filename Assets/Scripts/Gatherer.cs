using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Actions;
using Enums;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Gatherer : MonoBehaviour
{
    private bool moving;
    private bool harvesting;
    private Action _currentAction;
    private Queue<Action> ActionQueue { get; set; }
    private MapController _mapObject;
    
    //Gatherer Stats
    public float Carry;
    public float GatherSpeed;

    public float Carrying;
    
    // Start is called before the first frame update
    void Start()
    {
        ActionQueue = new Queue<Action>();
        _mapObject =  GameObject.Find("MapController").GetComponent<MapController>();
        Carry = 1;
        GatherSpeed = 2;
        Carrying = 0;
     
        if (_mapObject != null)
        {
            ActionQueue.Enqueue(new Action
            {
                ActionType = ActionType.Harvest,
                Destination = _mapObject.Resources.FirstOrDefault().WorldPosition
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = Time.deltaTime;

        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentAction.Destination, step);
            if (Vector3.Distance(transform.position, _currentAction.Destination) < 0.001f)
            {
                moving = false;
                harvesting = true;
            }
            
        }else if (harvesting)
        {
            this.Carrying = this.Carrying + _mapObject.Resources.FirstOrDefault().Gather(this.GatherSpeed, step);
            if (this.Carrying >= this.Carry)
            {
                //return extra
                var extra = this.Carrying - this.Carry;
                _mapObject.Resources.FirstOrDefault().AdjustAmount(extra);
                this.Carrying = this.Carry;
                //move to hub;
                
                ActionQueue.Enqueue(new Action
                {
                    ActionType = ActionType.Carry,
                    Destination = _mapObject.hubWorldLocation
                });
                this.harvesting = false;
            }
        }
        else
        {
            Debug.Log("Dequeueing task");
            _currentAction = ActionQueue.Dequeue();
            if (Vector3.Distance(transform.position, _currentAction.Destination) > 0.001f)
            {
                moving = true;
            }
        }
        
    }
}
