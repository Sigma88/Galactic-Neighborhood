namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class PluronKhato : Pack<PluronKhato>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Sigma-PluronKhato.v1.3.0.zip"; } }
        internal override string path { get { return "GameData/Sigma/PluronKhato/"; } }
    }
}
