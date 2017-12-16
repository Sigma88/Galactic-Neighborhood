namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class TransKeptunian : Pack<TransKeptunian>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Trans-Keptunian.v0.5.zip"; } }
        internal override string path { get { return "GameData/Trans-Keptunian/"; } }
        internal override string[] filter { get { return new string[] { path + "Mods/OPMCompatibility.cfg" }; } }
    }
}
