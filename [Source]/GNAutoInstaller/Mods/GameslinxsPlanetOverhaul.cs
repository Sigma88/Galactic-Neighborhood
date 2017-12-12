using System.IO;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class GPO : MonoBehaviour
    {
        static string archive;

        void Awake()
        {
            Events.InstallMods.Add(Install);
        }

        void Install()
        {
            // Install GPO
            archive = "PluginData/GalacticNeighborhood/Gameslinxs_Planet_Overhaul_Waiting_For_An_Update_That_Does_Not_Suck";

            if (File.Exists(archive) && !Directory.Exists("GameData/Olei/") && !Directory.Exists("GameData/Olei-Gaia/"))
            {
                string[] filter = new string[]
                {
                    "GameData/Olei/EVE/",
                    "GameData/Olei/LSM/",
                    "GameData/Olei/Skybox",
                    "GameData/Olei/GPO_",
                    "GameData/Olei-Gaia/EVE/"
                };

                Archive.UnZip(archive, "GameData/Olei/", "GameData/Olei/", filter);
                Archive.UnZip(archive, "GameData/Olei-Gaia/", "GameData/Olei-Gaia/", filter);
                if (!Directory.Exists("GameData/CTTP/")) Archive.UnZip(archive, "GameData/CTTP/", "GameData/CTTP/");
            }
        }
    }
}
