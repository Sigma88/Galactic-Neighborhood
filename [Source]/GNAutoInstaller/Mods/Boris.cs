namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Boris : Pack<Boris>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/BorisSystem.v0.5.zip"; } }
        internal override string path { get { return "GameData/PFSystems/"; } }
    }
}
