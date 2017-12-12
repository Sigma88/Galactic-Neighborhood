using System.IO;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Asclepius : MonoBehaviour
    {
        static string archive;

        void Awake()
        {
            Events.InstallMods.Add(Install);
        }

        void Install()
        {
            // Install GPP
            archive = "PluginData/GalacticNeighborhood/AsclepiusV3-0.zip";

            if (File.Exists(archive) && !Directory.Exists("GameData/Asclepius/"))
            {
                Archive.UnZip(archive, "GameData/Asclepius/", "GameData/Asclepius/");
            }
        }
    }
}
