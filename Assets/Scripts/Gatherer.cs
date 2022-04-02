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
    public int Carry { get; set; }
    public int GatherSpeed { get; set; }
    public int GatherLeft { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        ActionQueue = new Queue<Action>();
        _mapObject =  GameObject.Find("MapController").GetComponent<MapController>();
        Carry = 1;
        GatherSpeed = 2;
     
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
        if (moving)
        {
            float step = Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _currentAction.Destination, step);
            if (Vector3.Distance(transform.position, _currentAction.Destination) < 0.001f)
            {
                moving = false;
                harvesting = true;
            }
            
        }else if (harvesting)
        {
            _mapObject.Resources.FirstOrDefault().Gather(this);
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
