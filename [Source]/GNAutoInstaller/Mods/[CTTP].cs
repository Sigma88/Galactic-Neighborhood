using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class CTTP
    {
        static string archive { get { return "PluginData/GalacticNeighborhood/CTTP.v1.0.1.zip"; } }
        static string path { get { return "GameData/CTTP/"; } }

        internal static bool Check()
        {
            if (Directory.Exists(path)) return true;
            return File.Exists(archive) || File.Exists(AfterKerbin.Mod.archive) || File.Exists(BeforeKerbin.Mod.archive) || File.Exists(GPO.Mod.archive) || File.Exists(OPM.Mod.archive);
        }

        internal static void Install()
        {
            if (!Directory.Exists(path))
            {
                if (File.Exists(archive))
                {
                    Archive.UnZip(archive, path, path);
                }

                else

                if (File.Exists(AfterKerbin.Mod.archive))
                {
                    Archive.UnZip(AfterKerbin.Mod.archive, path, path);
                }

                else

                if (File.Exists(BeforeKerbin.Mod.archive))
                {
                    Archive.UnZip(BeforeKerbin.Mod.archive, path, path);
                }

                else

                if (File.Exists(GPO.Mod.archive))
                {
                    Archive.UnZip(GPO.Mod.archive, path, path);
                }

                else

                if (File.Exists(OPM.Mod.archive))
                {
                    Archive.UnZip(OPM.Mod.archive, path, path);
                }
            }
        }
    }
}
