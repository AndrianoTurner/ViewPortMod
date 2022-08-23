using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
namespace ViewPortMod
{
    [HarmonyPatch(typeof(PLServer), "ClaimShip")]
    internal class OnShipClaim
    {
        public static void Postfix(PLServer __instance)
        {
            if (__instance != null && PLEncounterManager.Instance.PlayerShip != null)
            {
                Variables.Initialized = false;
                Variables.inViewPortView = false;

                __instance.StartCoroutine(new EnterGamePatch.Wrapper().FindAllViewPortsCoroutine());
            }
        }
    }
}
