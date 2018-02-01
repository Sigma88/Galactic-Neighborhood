using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Kolyphemus : Pack<Kolyphemus>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Kolyphemus_System-Beta1.zip"; } }
        internal override string path { get { return "GameData/Kolyphemus/"; } }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "Kolyphemus/", path);
            }
        }
    }
}
