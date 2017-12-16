namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class UnchartedLands : Pack<UnchartedLands>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/UL.zip"; } }
        internal override string path { get { return "GameData/UnchartedLands/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "AsteroidSpawns.cfg",
                    path + "UL_RemoteTech.cfg"
                };
            }
        }
    }
}
