using System.IO;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Almost : MonoBehaviour
    {
        static string archive;
        static string sigdim;

        void Awake()
        {
            Events.InstallMods.Add(Install);
        }

        void Install()
        {
            // Install Almost
            archive = "PluginData/GalacticNeighborhood/Almost_Real_Solar_System-1.2.1.zip";
            sigdim = "PluginData/GalacticNeighborhood/Sigma-Dimensions.v0.9.6.zip";

            if (File.Exists(archive) && !Directory.Exists("GameData/(Almost)RealSolarSystem/"))
            {
                if (File.Exists(sigdim) || Directory.Exists("GameData/Sigma/Dimensions/"))
                {
                    string[] filter = new string[]
                    {
                        "GameData/(Almost)RealSolarSystem/Compatibility/KSCSwitcher/",
                        "GameData/(Almost)RealSolarSystem/Compatibility/RemoteTech/"
                    };

                    Archive.UnZip(archive, "GameData/(Almost)RealSolarSystem/", "GameData/(Almost)RealSolarSystem/", filter);

                    if (!Directory.Exists("GameData/Sigma/Dimensions/"))
                        Archive.UnZip(sigdim, "GameData/Sigma/Dimensions/", "GameData/Sigma/Dimensions/");
                }
            }
        }
    }
}
