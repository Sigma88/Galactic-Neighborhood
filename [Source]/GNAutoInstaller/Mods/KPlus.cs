namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class KPlus : Pack<KPlus>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/KPlus_v1.1.zip"; } }
        internal override string path { get { return "GameData/KPlus/"; } }
    }
}
