using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class OPM : Pack<OPM>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/OPM_Galileo.v1.2.4.zip"; } }
        internal override string path { get { return "GameData/OPM/"; } }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path + "KopernicusConfigs/", path + "KopernicusConfigs/");
                Archive.UnZip(archive, path + "Localization/", path + "Localization/");
                Archive.UnZip(archive, path + "OPM_Textures/", path + "OPM_Textures/");
                Archive.UnZip(archive, path + "OuterPlanetsMod-Galileo.version", path + "OuterPlanetsMod-Galileo.version");
                if (!Directory.Exists("GameData/CTTP/")) Archive.UnZip(archive, "GameData/CTTP/", "GameData/CTTP/");
            }
        }
    }
}
