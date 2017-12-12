using System.IO;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Arkas : MonoBehaviour
    {
        static string archive;

        void Awake()
        {
            Events.InstallMods.Add(Install);
        }

        void Install()
        {
            // Install GPP

            if (File.Exists(archive) && !Directory.Exists("GameData/Arkas/"))
            {
                Archive.UnZip(archive, "Files/Mod/Arkas/", "GameData/Arkas/");
                Archive.UnZip(archive, "Files/Mod/Moons/", "GameData/Arkas/Expansions/");
            }
        }
    }
}
