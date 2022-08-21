
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
namespace ViewPortMod
{
    [HarmonyPatch(typeof(PLPlayer),"Update")]
    internal class PLPlayerPatch
    {
        private float nextActionTime = 0.0f;
        public float period = 0.1f;
        public static void Postfix(PLPlayer __instance)
        {
            if(__instance != null && PLEncounterManager.Instance.PlayerShip != null && !Variables.Initialized)
            {
                Variables.viewPorts = Variables.FindAllViewPorts();
                Variables.Initialized = true;
            }
        }
    }

    

}