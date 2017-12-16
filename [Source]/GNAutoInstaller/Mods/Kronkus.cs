using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Kronkus : Pack<Kronkus>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/KronkusV1-3-4.zip"; } }
        internal override string path { get { return "GameData/Kronkus/"; } }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path);
                Archive.UnZip(archive, "GameData/Spud/", "GameData/Spud/");
            }
        }
    }
}
