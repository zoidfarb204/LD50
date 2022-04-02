using Enums;
using UnityEngine;

namespace Actions
{
    public class Action
    {
        public ActionType ActionType { get; set; }
        public Vector3 Destination { get; set; }
    }
}