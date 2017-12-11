using System.IO;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Kolyphemus : MonoBehaviour
    {
        static string archive;

        void Awake()
        {
            Events.InstallMods.Add(Install);
        }

        void Install()
        {
            // Install GPP
            archive = "PluginData/GalacticNeighborhood/Kolyphemus_System-Beta1.zip";

            if (File.Exists(archive) && !Directory.Exists("GameData/Kolyphemus/"))
            {
                Archive.UnZip(archive, "Kolyphemus/", "GameData/Kolyphemus/");
            }
        }
    }
}
