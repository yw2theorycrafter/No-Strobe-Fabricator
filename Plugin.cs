using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace No_Strobe_Fabricator
{
    [BepInPlugin(MyGuid, PluginName, VersionString)]
    public class Plugin : BaseUnityPlugin
    {
        private const string MyGuid = "com.yw2theorycrafter.nostrobefabricator";
        private const string PluginName = "No Strobe Fabricator";
        private const string VersionString = "2.0.0";

        public new static ManualLogSource Logger { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        private void Awake()
        {
            // plugin startup logic
            Logger = base.Logger;

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{MyGuid}");
            Logger.LogInfo($"Plugin {MyGuid} is loaded!");
        }
    }
}
