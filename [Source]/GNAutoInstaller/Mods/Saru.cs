using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Saru : Pack<Saru>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Saru_Planet_Pack-0.1.zip"; } }
        internal override string path { get { return "GameData/SaruPack/"; } }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "Saru-Planet-Pack-0.1/GameData/SaruPack/", path);
            }
        }
    }
}
