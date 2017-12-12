using System.IO;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Kronkus : MonoBehaviour
    {
        static string archive;

        void Awake()
        {
            Events.InstallMods.Add(Install);
        }

        void Install()
        {
            // Install GPP
            archive = "PluginData/GalacticNeighborhood/KronkusV1-3-4.zip";

            if (File.Exists(archive) && !Directory.Exists("GameData/Kronkus/"))
            {
                Archive.UnZip(archive, "GameData/Kronkus/", "GameData/Kronkus/");
                Archive.UnZip(archive, "GameData/Spud/", "GameData/Spud/");
            }
        }
    }
}
