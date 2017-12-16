using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Farlo : Pack<Farlo>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Farlo_Planetary_Pack-v0.1.2.zip"; } }
        internal override string path { get { return "GameData/PlanetPack_Farlo/"; } }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "PlanetPack_Farlo/", path);
            }
        }
    }
}
