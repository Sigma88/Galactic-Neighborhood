namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Almost : Pack<Almost>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Almost_Real_Solar_System-1.2.3.zip"; } }
        internal override string path { get { return "GameData/(Almost)RealSolarSystem/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "Compatibility/KSCSwitcher/",
                    path + "Compatibility/RemoteTech/"
                };
            }
        }

        internal override bool Check()
        {
            return SD.Check() && base.Check();
        }
    }
}
