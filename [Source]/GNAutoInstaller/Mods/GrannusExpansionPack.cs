using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class GEP : Pack<GEP>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/GrannusExpansionPack_1.0.1.5.zip"; } }
        internal override string path { get { return "GameData/GEP/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "GEP_Configs",
                    path + "GEP_Resources",
                    path + "GEP_Scatterer",
                    path + "MiniAVC.dll"
                };
            }
        }

        internal override bool Check()
        {
            if (!Directory.Exists(path))
            {
                return File.Exists(archive) && GPP.Mod.Check();
            }

            return true;
        }
    }
}
