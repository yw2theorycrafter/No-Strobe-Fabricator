using HarmonyLib;

namespace com.yw2theorycrafter.nostrobefabricator.Patches
{
    [HarmonyPatch(typeof(Fabricator))]
    [HarmonyPatch("Start")]
    public class Fabricator_Start_Patch
    {
        static void Prefix(Fabricator __instance)
        {
#if DEBUG
            Plugin.Logger.LogInfo("Patching fabricator " + __instance.ToString());
#endif
            var couldFind = false;
            foreach (UnityEngine.Transform child in __instance.transform)
            {
                if (child.name.Equals("fabricatorLight"))
                {
                    //Disable the entire light
                    child.gameObject.SetActive(false);
                    couldFind = true;
#if DEBUG
                    Plugin.Logger.LogInfo("Successfully disabled " + child.ToString() + " of fabricator " + __instance.ToString());
#endif
                    goto searchEnd;
                }
                //Handle the MapRoomFabricator, though it seems like the map fabricator's fabricatorLight doesn't show up anyway?
                if (child.name.Equals("submarine_fabricator_02"))
                {
                    foreach (UnityEngine.Transform child2 in child)
                    {
                        if (child2.name.Equals("fabricatorLight"))
                        {
                            //Disable the entire light
                            child2.gameObject.SetActive(false);
                            couldFind = true;
#if DEBUG
                            Plugin.Logger.LogInfo("Successfully disabled " + child2.ToString() + " of fabricator " + __instance.ToString());
#endif
                            goto searchEnd;
                        }
                    }
                }
            }
        searchEnd: if (!couldFind)
            {
                Plugin.Logger.LogWarning("WARN: Couldn't find fabricatorLight child of fabricator " + __instance.ToString());
            }
        }
    }
}
