using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using HarmonyLib;
using PulsarModLoader;
namespace ViewPortMod
{
    internal class Variables
    {
        public static bool Initialized;
        public static List<ViewPort> viewPorts = new List<ViewPort>();
        public static bool inViewPortView = false;

        public static void FindAllViewPorts()
        {
            List<ViewPort> list = new List<ViewPort>();
            foreach (GameObject gameobject in UnityEngine.Object.FindObjectsOfType<GameObject>())
            {
                if (gameobject.name.Contains("ViewPort"))
                {
                    viewPorts.Add(new ViewPort(gameobject.transform));
                }

            }
        }
  
        
    }
}
