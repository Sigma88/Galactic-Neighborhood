namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Keridani : Pack<Keridani>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/KeridaniContinued.v0.1.zip"; } }
        internal override string path { get { return "GameData/Planets/"; } }
    }
}
