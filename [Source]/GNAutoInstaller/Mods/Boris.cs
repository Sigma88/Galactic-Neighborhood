using System.IO;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Boris : MonoBehaviour
    {
        static string archive;

        void Awake()
        {
            Events.InstallMods.Add(Install);
        }

        void Install()
        {
            // Install Boris
            archive = "PluginData/GalacticNeighborhood/BorisSystem.v0.5.zip";

            if (File.Exists(archive) && !Directory.Exists("GameData/PFSystems/"))
            {
                Archive.UnZip(archive, "GameData/PFSystems/", "GameData/PFSystems/");
            }
        }
    }
}
