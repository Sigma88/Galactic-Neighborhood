using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Suthe : Pack<Suthe>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Suthe_Solar_System_Overhaul_Mod-1.9.4.zip"; } }
        internal override string path { get { return "GameData/Suthe/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    "SutheMod/GameData/Suthe/COMPATIBILITYPATCHES/CustomAsteroids/",
                    "SutheMod/GameData/Suthe/COMPATIBILITYPATCHES/EVE/",
                    "SutheMod/GameData/Suthe/COMPATIBILITYPATCHES/Scatterer/"
                };
            }
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "SutheMod/GameData/Suthe/", path, filter);
            }
        }
    }
}
