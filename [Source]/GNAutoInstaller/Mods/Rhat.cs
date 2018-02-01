namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Rhat : Pack<Rhat>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/RhatsPackContinued.v0.1.zip"; } }
        internal override string path { get { return "GameData/RPM/"; } }
    }
}
