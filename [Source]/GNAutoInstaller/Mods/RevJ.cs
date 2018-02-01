using System.IO;


namespace GNAutoInstallerPlugin
{
    class RevJ
    {
        internal static string archive = "PluginData/GalacticNeighborhood/GregroxMuns_Revolting_Jool_Recolor-1.zip";
        internal static string path = "GameData/RevoltingJoolRecolor/";

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
                Archive.UnZip(archive, path, path);
            }
        }
    }
}
