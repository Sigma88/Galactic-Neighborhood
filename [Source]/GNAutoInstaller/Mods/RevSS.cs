using System.IO;


namespace GNAutoInstallerPlugin
{
    class RevSS
    {
        internal static string archive = "PluginData/GalacticNeighborhood/RevampedStockSystemv0.6.zip";
        internal static string path = "GameData/RevampedStockSystem/";

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
                Archive.UnZip(archive, "RevampedStockSystem/", path);
            }
        }
    }
}
