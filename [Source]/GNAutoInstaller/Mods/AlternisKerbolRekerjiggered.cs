using System.IO;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class AKR : MonoBehaviour
    {
        static string archive;

        void Awake()
        {
            Events.InstallMods.Add(Install);
        }

        void Install()
        {
            // Install AKR
            archive = "PluginData/GalacticNeighborhood/AlternisKerbolRekerjiggered2.2.0.zip";

            if (File.Exists(archive) && !Directory.Exists("GameData/AlternisKerbolRekerjiggered/"))
            {
                string[] filter = new string[]
                {
                    "GameData/AlternisKerbolRekerjiggered/ModCompatibility/EVE_Clouds/",
                    "GameData/AlternisKerbolRekerjiggered/ModCompatibility/PlanetPackCompatibility",
                    "GameData/AlternisKerbolRekerjiggered/ModCompatibility/PluginData",
                    "GameData/AlternisKerbolRekerjiggered/ModCompatibility/Kronometer.cfg",
                    "GameData/AlternisKerbolRekerjiggered/ModCompatibility/SLIPPIST-1.cfg"
                };

                Archive.UnZip(archive, "GameData/AlternisKerbolRekerjiggered/", "GameData/AlternisKerbolRekerjiggered/", filter);
            }
        }
    }
}
