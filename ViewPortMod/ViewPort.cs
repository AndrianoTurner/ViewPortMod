using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ViewPortMod
{
    internal class ViewPort
    {
        public Transform transform;
        public float ControllerChange = 0.3f;
        public ViewPort(Transform transform)
        {
            this.transform = transform;
        }
    }
}
