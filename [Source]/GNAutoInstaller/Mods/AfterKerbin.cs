using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class AfterKerbin : Pack<AfterKerbin>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/After_Kerbin_Planet_Mod-1.3.0.zip"; } }
        internal override string path { get { return "GameData/AfterKerbin/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "_Core00/KEX_EVAfootprints.cfg",
                    path + "EVE/",
                    path + "LSM/",
                    path + "scatterer/",
                    path + "LoadingScreenManager.dll"
                };
            }
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path, filter);

                CTTP.Install();
            }
        }
    }
}
