using System.Collections;
using System.Collections.Generic;
using Enums;
using Inventory;
using UnityEditor;
using UnityEngine;


public class GathererController : MonoBehaviour
{
    public GameObject gathererPrefab;
    // Start is called before the first frame update
    void Start()
    {
        var gatherer = Instantiate(gathererPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        var gathererScript = gatherer.GetComponent<Gatherer>();
        gathererScript.Type = ResourceType.Wood;
        gathererScript.GathererInventory = new Inventory.Inventory
        {
            NumSlots = 1,
            Slots = new List<ISlot>()
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
