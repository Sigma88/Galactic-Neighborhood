using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class GPO : Pack<GPO>
    {
        internal static string[] textures { get { return new string[] { "PluginData/GalacticNeighborhood/Gameslinxs_Planet_Overhaul_Waiting_For_An_Update_That_Does_Not_Suck", "GameData/CTTP/" }; } }

        internal override string archive { get { return textures[0]; } }
        internal override string path { get { return "GameData/Olei/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "EVE/",
                    path + "LSM/",
                    path + "Skybox/",
                    path + "GPO_"
                };
            }
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path, filter);

                string gaia = "GameData/Olei-Gaia/";
                if (!Directory.Exists(gaia)) Archive.UnZip(archive, gaia, gaia, new[] { "GameData/Olei-Gaia/EVE/" });
                
                CTTP.Install();
            }
        }
    }
}
