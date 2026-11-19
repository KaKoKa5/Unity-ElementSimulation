using System.Collections.Generic;
using Runtime.Project.Scripts.Core;
using UnityEngine;

namespace Project.Scripts.Core.ElementSysteme.RunTime
{
    public class ElementChain : ElementInfo
    {
        public List<ElementSimulation> neighbours = new List<ElementSimulation>();
        private void OnTriggerEnter(Collider other)
        {
            ElementSimulation element = other.GetComponentInChildren<ElementSimulation>();

            if (element != null && !neighbours.Contains(element))
            {
                neighbours.Add(element);
            }
                
        }
        private void OnTriggerExit(Collider other)
        {
            ElementSimulation element = other.GetComponentInChildren<ElementSimulation>();

            if (element != null)
            {
                neighbours.Remove(element);
            }

        }
    
    }
}
