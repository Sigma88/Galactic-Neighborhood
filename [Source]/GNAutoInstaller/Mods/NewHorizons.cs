namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class NewHorizons : Pack<NewHorizons>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/New_Horizons.zip"; } }
        internal override string path { get { return "GameData/New_Horizons/"; } }
    }
}
