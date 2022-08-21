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
        public static List<ViewPort> viewPorts;
        public static bool inViewPortView = false;

        public static List<ViewPort> FindAllViewPorts()
        {
            List<ViewPort> list = new List<ViewPort>();
            foreach (GameObject gameobject in UnityEngine.Object.FindObjectsOfType<GameObject>())
            {
                if (gameobject.name.Contains("ViewPort"))
                {
                    list.Add(new ViewPort(gameobject.transform));
                }

            }
            return list;
        }
        [HarmonyPatch(typeof(PLGlobal), "EnterNewGame")]
        class StartPatch
        { 
            static void Postfix()
            {
                viewPorts = new List<ViewPort>();
                inViewPortView = false;
                Initialized = false;
#if DEBUG
                PulsarModLoader.Utilities.Logger.Info("Variables.StartPatch::Postfix");
#endif
            }
        }
        
    }
}
