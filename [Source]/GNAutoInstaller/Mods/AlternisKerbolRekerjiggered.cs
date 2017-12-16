namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class AKR : Pack<AKR>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/AlternisKerbolRekerjiggered2.2.0.zip"; } }
        internal override string path { get { return "GameData/AlternisKerbolRekerjiggered/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "ModCompatibility/EVE_Clouds/",
                    path + "ModCompatibility/PlanetPackCompatibility",
                    path + "ModCompatibility/PluginData",
                    path + "ModCompatibility/Kronometer.cfg",
                    path + "ModCompatibility/SLIPPIST-1.cfg"
                };
            }
        }
    }
}
