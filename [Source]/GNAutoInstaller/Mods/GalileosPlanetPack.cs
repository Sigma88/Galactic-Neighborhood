using System.IO;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class GPP : MonoBehaviour
    {
        static string archive;
        static string textures;

        void Awake()
        {
            Events.InstallMods.Add(Install);
        }
        
        void Install()
        {
            // Install GPP
            archive = "PluginData/GalacticNeighborhood/Galileos.Planet.Pack.1.5.88.zip";
            textures = "PluginData/GalacticNeighborhood/GPP_Textures-3.0.0.zip";

            if (File.Exists(archive) && File.Exists(textures) && !Directory.Exists("GameData/GPP/"))
            {
                string[] filter = new string[]
                {
                    "GameData/GPP/Agencies",
                    "GameData/GPP/GPP_Configs",
                    "GameData/GPP/GPP_KSC++",
                    "GameData/GPP/GPP_Renamer",
                    "GameData/GPP/GPP_Replacements",
                    "GameData/GPP/GPP_Scatterer",
                    "GameData/GPP/GPP_Skybox",
                    "GameData/GPP/GPP_SuitProgression",
                    "GameData/GPP/GPP_WaterLaunch",
                    "GameData/GPP/GPP_Skybox",
                    "GameData/GPP/LoadingScreens",
                    "GameData/GPP/GPP_KSPedia.ksp",
                    "GameData/GPP/MiniAVC.dll"
                };

                Archive.UnZip(archive, "GameData/GPP/", "GameData/GPP/", filter);
                Archive.UnZip(archive, "GameData/GPP/GPP_Configs/GPP_KopernicusSettings.cfg", "GameData/GPP/GPP_Configs/GPP_KopernicusSettings.cfg");
                Archive.UnZip(textures, "GameData/GPP/GPP_Textures/", "GameData/GPP/GPP_Textures/");
            }
        }
    }
}
