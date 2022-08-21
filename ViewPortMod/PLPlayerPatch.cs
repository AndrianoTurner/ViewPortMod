
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
namespace ViewPortMod
{
   
    [HarmonyPatch(typeof(PLGlobal), "EnterNewGame")]
    internal class EnterGamePatch
    {
        public static void Postfix(PLGlobal __instance)
        {
            if (PLEncounterManager.Instance.PlayerShip != null && !Variables.Initialized)
            {
                __instance.StartCoroutine(new Wrapper().FindAllViewPortsCoroutine());
                Variables.Initialized = true;
            }
        }

        

        internal class Wrapper
        {
            public IEnumerator FindAllViewPortsCoroutine()
            {
                yield return new WaitForSeconds(5f);
                Variables.FindAllViewPorts();

            }
        }
    }







}