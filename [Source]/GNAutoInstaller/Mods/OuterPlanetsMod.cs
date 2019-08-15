using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class OPM : Pack<OPM>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Outer_Planets_Mod-2.2.5.zip"; } }
        internal override string path { get { return "GameData/OPM/"; } }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path + "KopernicusConfigs/", path + "KopernicusConfigs/");
                Archive.UnZip(archive, path + "Localization/", path + "Localization/");
                Archive.UnZip(archive, path + "OPM_Textures/", path + "OPM_Textures/");
                Archive.UnZip(archive, path + "OuterPlanetsMod.version", path + "OuterPlanetsMod.version");

                CTTP.Install();
            }
        }
    }
}
