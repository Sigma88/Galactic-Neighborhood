using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class AfterKerbin : Pack<AfterKerbin>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/After_Kerbin_Planet_Mod-1.0.3.zip"; } }
        internal override string path { get { return "GameData/AfterKerbin/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    "AfterKerbin/_Core00/KEX_EVAfootprints.cfg",
                    "AfterKerbin/EVE/",
                    "AfterKerbin/LSM/",
                    "AfterKerbin/scatterer/",
                    "AfterKerbin/LoadingScreenManager.dll"
                };
            }
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "AfterKerbin/", path, filter);

                CTTP.Install();
            }
        }
    }
}
