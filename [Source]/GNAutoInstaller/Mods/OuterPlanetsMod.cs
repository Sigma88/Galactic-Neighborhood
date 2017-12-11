using System.IO;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class OPM : MonoBehaviour
    {
        static string archive;

        void Awake()
        {
            Debug.Log("SigmaLog: Adding mod: OPM");
            Events.InstallMods.Add(Install);
        }

        void Install()
        {
            Debug.Log("SigmaLog: Installing mod: OPM");
            // Install OPM
            archive = "PluginData/GalacticNeighborhood/OPM_Galileo.v1.2.4.zip";

            if (File.Exists(archive) && !Directory.Exists("GameData/OPM/"))
            {
                Archive.UnZip(archive, "GameData/OPM/KopernicusConfigs/", "GameData/OPM/KopernicusConfigs/");
                Archive.UnZip(archive, "GameData/OPM/Localization/", "GameData/OPM/Localization/");
                Archive.UnZip(archive, "GameData/OPM/OPM_Textures/", "GameData/OPM/OPM_Textures/");
                Archive.UnZip(archive, "GameData/OPM/OuterPlanetsMod-Galileo.version", "GameData/OPM/OuterPlanetsMod-Galileo.version");
                if (!Directory.Exists("GameData/CTTP/")) Archive.UnZip(archive, "GameData/CTTP/", "GameData/CTTP/");
            }
        }
    }
}
