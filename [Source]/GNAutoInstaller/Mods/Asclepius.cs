namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Asclepius : Pack<Asclepius>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/AsclepiusV5-0.zip"; } }
        internal override string path { get { return "GameData/Asclepius/"; } }
    }
}
