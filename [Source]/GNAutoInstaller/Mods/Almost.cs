using System.IO;
using System.Linq;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Almost : MonoBehaviour
    {
        static string archive;

        void Awake()
        {
            Events.InstallMods.Add(Install);
        }

        void Install()
        {
            // Check Dependancies
            if (AssemblyLoader.loadedAssemblies.FirstOrDefault(a => a.name == "SigmaDimensions") == null) return;

            // Install Almost
            archive = "PluginData/GalacticNeighborhood/Almost_Real_Solar_System-1.2.1.zip";

            if (File.Exists(archive) && !Directory.Exists("GameData/(Almost)RealSolarSystem/"))
            {
                string[] filter = new string[]
                {
                        "GameData/(Almost)RealSolarSystem/Compatibility/KSCSwitcher/",
                        "GameData/(Almost)RealSolarSystem/Compatibility/RemoteTech/"
                };

                Archive.UnZip(archive, "GameData/(Almost)RealSolarSystem/", "GameData/(Almost)RealSolarSystem/", filter);
            }
        }
    }
}
