namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Jungis : Pack<Jungis>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Jungis Planet Pack.zip"; } }
        internal override string path { get { return "GameData/Jungis/"; } }
    }
}
