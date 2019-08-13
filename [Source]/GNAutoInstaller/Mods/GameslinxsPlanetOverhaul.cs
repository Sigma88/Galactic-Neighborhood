using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class GPO : Pack<GPO>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Gameslinx.s.Planet.Overhaul.3.4.zip"; } }
        internal override string path { get { return "GameData/GPO/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "Configs/FixPQS.cfg",
                    path + "EVE/",
                    path + "LoadingScreens/",
                    path + "scatterer/",
                    path + "ShoutAtPeopleWhoCantInstallModsProperly/",
                    path + "Skybox/",
                    path + "GPO_RemoteTech.cfg",
                    path + "GPO_Scatterer.cfg",
                    path + "GPO_Scatterer_Settings.cfg",
                    path + "GPO_ScattererInitialiser.cfg",
                    path + "GPO_Science Balance Pass.cfg",
                    path + "GPO_Skybox.cfg",
                    path + "GPO_Terrain_Settings.cfg",
                    path + "MiniAVC.dll"
                };
            }
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path, filter);

                CTTP.Install();
            }
        }
    }
}
