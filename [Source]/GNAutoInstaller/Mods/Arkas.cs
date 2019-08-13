using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Arkas : Pack<Arkas>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Planet_Arkas_Development_Edition-4.0.zip"; } }
        internal override string path { get { return "GameData/Arkas/"; } }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "Files/Mod/Arkas/", path);
                Archive.UnZip(archive, "Files/Moons/", path + "Expansions/");
            }
        }
    }
}
