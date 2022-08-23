using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
namespace ViewPortMod
{
    [HarmonyPatch(typeof(PLGameStatic),"Update")]
    internal class GameStaticPatch
    {
        public static void Postfix(PLGameStatic __instance)
        {
            if (__instance != null && Variables.Initialized && PLNetworkManager.Instance.MyLocalPawn != null)
            {
                if (Variables.viewPorts != null)
                {
                    foreach (ViewPort view in Variables.viewPorts)
                    {
                        if (view.transform != null && Vector3.SqrMagnitude(PLNetworkManager.Instance.MyLocalPawn.transform.position - view.transform.position) < 4f)
                        {
                            if (Time.unscaledTime - view.ControllerChange > 0.2f)
                            {
                                if (!Variables.inViewPortView)
                                {

                                    PLGlobal.Instance.SetBottomInfo("", "Use Viewport ", "", "activate_station");
                                    if (PLInput.Instance.GetButtonUp(PLInputBase.EInputActionName.activate_station))
                                    {
                                        view.ControllerChange = Time.unscaledTime;
                                        Variables.inViewPortView = true;
                                        PLCameraSystem.Instance.ChangeCameraMode(new PLCameraMode_Pilot(PLNetworkManager.Instance.LocalPlayer.StartingShip));

                                    }
                                }
                                else
                                {
                                    PLGlobal.Instance.SetBottomInfo("", "", "", "");
                                    if (PLInput.Instance.GetButtonUp(PLInputBase.EInputActionName.activate_station))
                                    {
                                        Variables.inViewPortView = false;
                                        PLCameraSystem.Instance.ChangeCameraMode(new PLCameraMode_LocalPawn());
                                    }
                                }
                            }




                        }
                    }
                }
                
            }
            
            
        }
    }
}