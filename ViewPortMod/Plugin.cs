using PulsarModLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewPortMod
{
    public class Plugin : PulsarMod
    {
        public override string HarmonyIdentifier()
        {
            return "com.ViewPortMod";
        }

        public override string Author => "Rayman";
        public override string ShortDescription => "Adds functionality to viewports";
        public override string Name => "ViewPortMod";
        public override string Version => "0.0.4";
    }
}
