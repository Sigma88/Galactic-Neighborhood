using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class BeforeKerbin : Pack<BeforeKerbin>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Before_Kerbin_Planet_Pack_-_2_Billion_Years_Ago-1.1a.zip"; } }
        internal override string path { get { return "GameData/BeforeKerbin/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "_Core00/KEX_EVAfootprints.cfg",
                    path + "Compatibility/",
                    path + "EVE/",
                    path + "LSM/",
                    path + "scatterer/",
                    path + "Asteroids.cfg",
                    path + "LoadingScreenManager.dll"
                };
            }
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path, filter);

                string[] atlas = File.ReadAllLines(path + "Configs/Atlas.cfg");
                atlas[0] = "@Kopernicus:FOR[BK]";
                File.Delete(path + "Configs/Atlas.cfg");
                File.WriteAllLines(path + "Configs/Atlas.cfg", atlas);

                CTTP.Install();
            }
        }
    }
}
