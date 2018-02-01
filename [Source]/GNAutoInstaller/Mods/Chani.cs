namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Chani : Pack<Chani>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/ChaniPackContinued.v0.1.zip"; } }
        internal override string path { get { return "GameData/ChaniPack/"; } }
    }
}
