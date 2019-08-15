using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class OtherWorlds : Pack<OtherWorlds>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Other.Worlds.Reboot.0.5.zip"; } }
        internal override string path { get { return "GameData/OtherWorldsReboot/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "CercaniSystem/Clouds/",
                    path + "CercaniSystem/Scatterer/",
                    path + "ConfigurationFiles",
                    path + "LoadingScreens",
                    path + "Parts"
                };
            }
        }

        internal override bool Check()
        {
            if (Directory.Exists(path)) return true;

            return File.Exists(archive) && CTTP.Check();
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path, filter);
                Archive.UnZip(archive, path + "ConfigurationFiles/Localization", path + "ConfigurationFiles/Localization");

                CTTP.Install();
            }
        }
    }
}
