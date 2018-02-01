using System.IO;


namespace GNAutoInstallerPlugin
{
    class DRP
    {
        internal static string archive = "PluginData/GalacticNeighborhood/DunaRestorationProject.zip";
        internal static string path = "GameData/DunaRestorationProject/";

        internal static bool Check()
        {
            UnityEngine.Debug.Log("SigmaLog: DRP.Check");
            if (File.Exists(SASS.Mod.archive))
            {
                return File.Exists(archive) || Directory.Exists(path);
            }

            return false;
        }

        internal static void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "DunaRestorationProject/", path);
            }
        }
    }
}
