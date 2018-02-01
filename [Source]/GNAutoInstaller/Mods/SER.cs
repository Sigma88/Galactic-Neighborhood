using System.IO;


namespace GNAutoInstallerPlugin
{
    class SER
    {
        internal static string archive = "PluginData/GalacticNeighborhood/Sigma-EveRecolor.v1.2.4.zip";
        internal static string path = "GameData/Sigma/EveRecolor/";

        internal static bool Check()
        {
            UnityEngine.Debug.Log("SigmaLog: SER.Check");
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
                Archive.UnZip(archive, path, path);
            }
        }
    }
}
