using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Sylandro : Pack<Sylandro>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Sylandro's Planet Warehouse Version 1.zip"; } }
        internal override string path { get { return "GameData/Rictell/"; } }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "Rictell/", path);
            }
        }
    }
}
