using System.IO;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Suthe : MonoBehaviour
    {
        static string archive;

        void Awake()
        {
            Events.InstallMods.Add(Install);
        }
        
        void Install()
        {
            // Install Suthe
            archive = "PluginData/GalacticNeighborhood/Suthe_Solar_System_Overhaul_Mod-1.9.4.zip";

            if (File.Exists(archive) && !Directory.Exists("GameData/Suthe/"))
            {
                string[] filter = new string[]
                {
                    "SutheMod/GameData/Suthe/COMPATIBILITYPATCHES/CustomAsteroids/",
                    "SutheMod/GameData/Suthe/COMPATIBILITYPATCHES/EVE/",
                    "SutheMod/GameData/Suthe/COMPATIBILITYPATCHES/Scatterer/"
                };

                Archive.UnZip(archive, "SutheMod/GameData/Suthe/", "GameData/Suthe/", filter);
            }
        }
    }
}
