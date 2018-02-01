using System.IO;


namespace GNAutoInstallerPlugin
{
    class SNep
    {
        internal static string archive = "PluginData/GalacticNeighborhood/GregroxNeptune.zip";
        internal static string path = "GameData/GregroxNeptune/";

        internal static bool Check()
        {
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
                Archive.UnZip(archive, "GregroxNeptune/", path);
            }
        }
    }
}
