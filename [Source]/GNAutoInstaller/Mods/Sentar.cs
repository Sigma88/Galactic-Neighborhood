using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Sentar : Pack<Sentar>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Sentar_Expansion-1.0.zip"; } }
        internal override string path { get { return "GameData/SentarExpansion/"; } }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "SentarExpansion/", path);
            }
        }
    }
}
