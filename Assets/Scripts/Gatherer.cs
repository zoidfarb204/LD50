using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Actions;
using Enums;
using Inventory;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Tilemaps;

public class Gatherer : MonoBehaviour
{
    private Action _currentAction;
    private Queue<Action> ActionQueue { get; set; }
    private MapController _mapObject;
    private BuildingController _buildingController;
    
    //Gatherer Stats
    public float Carry;
    public float GatherSpeed;
    public Inventory.Inventory GathererInventory { get; set; }
    public ResourceType Type { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        ActionQueue = new Queue<Action>();
        _mapObject =  GameObject.Find("MapController").GetComponent<MapController>();
        _buildingController = GameObject.Find("BuildingController").GetComponent<BuildingController>();
        Carry = 1;
        GatherSpeed = 2;
     
        if (_mapObject != null)
        {
            var building = _buildingController.Buildings.FirstOrDefault(x => x.Type == BuildingType.Forrest); // assuming wood here should change with more resources
            ActionQueue.Enqueue(new Action
            {
                ActionType = ActionType.Harvest,
                Destination = building.WorldLocation,
                Building = building
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = Time.deltaTime;
        float distanceToDestination = 0;
        if (_currentAction != null)
        {
            distanceToDestination = Vector3.Distance(transform.position, _currentAction.Destination);
        }

        switch (_currentAction?.ActionType)
        {
            case ActionType.Harvest:
                Harvest(distanceToDestination, step);
                break;
            case ActionType.Put:
                Put(distanceToDestination, step);
                break;
            default:
                DequeueTask();
                break;
        }
    }

    private void DequeueTask()
    {
        Debug.Log("Dequeueing task");
        if (ActionQueue.Count == 0)
        {
            Debug.Log("No Task");
            return;
        }
        _currentAction = ActionQueue.Dequeue();
    }

    private void Put(float distanceToDestination, float step)
    {
        if (distanceToDestination > .001f)
        {
            Move(step);
        }
        else
        {
            var buildingSlot = _currentAction.Building.Inventory.GetSlot(Type);
            var gatherSlot = GathererInventory.GetSlot(Type);
            Inventory.Inventory.TransferInventory(buildingSlot, gatherSlot, step);
            if (gatherSlot.Amount <= 0)
            {
                //Go Harvest More
                _currentAction = null;
                var building = _buildingController.Buildings.FirstOrDefault(x => x.Type == BuildingType.Forrest); // assuming wood here should change with more resources
                ActionQueue.Enqueue(new Action
                {
                    ActionType = ActionType.Harvest,
                    Destination = building.WorldLocation,
                    Building = building
                });
            }
        }
    }

    private void Harvest(float distanceToDestination, float step)
    {
        if (distanceToDestination > .001f)
        {
            Move(step);
        }
        else
        {
            var buildingSlot = _currentAction.Building.Inventory.GetSlot(Type);
            var gatherSlot = GathererInventory.GetSlot(Type);
            Inventory.Inventory.TransferInventory(gatherSlot, buildingSlot, step);
            if (gatherSlot.Amount >= this.Carry)
            {
                //Return extra
                Inventory.Inventory.TransferInventory(buildingSlot, gatherSlot, gatherSlot.Amount - this.Carry);
                
                //move to hub;
                var building = _buildingController.Buildings.FirstOrDefault(x => x.Type == BuildingType.Hub);
                ActionQueue.Enqueue(new Action
                {
                    ActionType = ActionType.Put,
                    Destination = building.WorldLocation,
                    Building =building
                });
                _currentAction = null;
            }
        }
    }

    private void Move(float step)
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentAction.Destination, step);
    }
}
