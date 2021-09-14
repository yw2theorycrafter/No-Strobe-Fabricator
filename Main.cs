using HarmonyLib;
using QModManager.API.ModLoading;
using QModManager.API;
using System.Reflection;

namespace No_Strobe_Fabricator
{
    // Your main patching class must have the QModCore attribute (and must be public)
    [QModCore]
    public static class Main
    {
        // Your patching method must have the QModPatch attribute (and must be public)
        [QModPatch]
        public static void Patch()
        {
            // Add your patching code here
            //QModServices.Main.AddCriticalMessage("No Strobe Fabricator loaded.");
            Harmony harmony = new Harmony("com.yw2theorycrafter.nostrobefabricator");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
