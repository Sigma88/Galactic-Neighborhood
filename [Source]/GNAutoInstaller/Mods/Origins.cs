namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Origins : Pack<Origins>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Kerbol_Origins-v.0.4.9.zip"; } }
        internal override string path { get { return "GameData/KerbolOrigins/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "AsteroidSystem/",
                    path + "Contracts/",
                    path + "Flags/",
                    path + "Karbonite/",
                    path + "Parts/",
                    path + "KO_AntennaRange.cfg",
                    path + "KO_RemoteTech.cfg",
                    path + "KO_ResearchBodies.cfg"
                };
            }
        }
    }
}
