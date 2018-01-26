using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class CTTP : Pack<CTTP>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/CTTP.v1.0.1.zip"; } }
        internal override string path { get { return "GameData/CTTP/"; } }

        internal override bool Check()
        {
            if (Directory.Exists(path)) return true;
            return File.Exists(archive) || File.Exists(OPM.Mod.archive) || File.Exists(GPO.Mod.archive);
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                if (File.Exists(archive))
                {
                    Archive.UnZip(archive, path, path);
                }

                else

                if (File.Exists(OPM.Mod.archive))
                {
                    Archive.UnZip(OPM.Mod.archive, path, path);
                }

                else

                if (File.Exists(GPO.Mod.archive))
                {
                    Archive.UnZip(GPO.Mod.archive, path, path);
                }
            }
        }
    }
}
