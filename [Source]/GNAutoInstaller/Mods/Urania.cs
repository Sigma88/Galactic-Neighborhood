using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Urania : Pack<Urania>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/SUS_08.zip"; } }
        internal override string path { get { return "GameData/Sido_Urania_System/"; } }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "SUS_08/Sido_Urania_System/", path);
            }
        }
    }
}
