using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class GPP : Pack<GPP>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Galileos-Planet-Pack-1.6.0.1.zip"; } }
        internal override string path { get { return "GameData/GPP/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "Agencies",
                    path + "GPP_Configs",
                    path + "GPP_InstallationChecker",
                    path + "GPP_KSC++",
                    path + "GPP_Renamer",
                    path + "GPP_Replacements",
                    path + "GPP_Scatterer",
                    path + "GPP_Skybox",
                    path + "GPP_SuitProgression",
                    path + "GPP_WaterLaunch",
                    path + "GPP_Skybox",
                    path + "LoadingScreens",
                    path + "GPP_KSPedia.ksp",
                    path + "MiniAVC.dll"
                };
            }
        }
        static string textures = "PluginData/GalacticNeighborhood/GPP_Textures-4.0.0.zip";

        internal override bool Check()
        {
            if (!Directory.Exists(path))
            {
                return File.Exists(archive) && File.Exists(textures);
            }

            return true;
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path, filter);
                Archive.UnZip(archive, path + "GPP_Configs/GPP_KopernicusSettings.cfg", path + "GPP_Configs/GPP_KopernicusSettings.cfg");
                Archive.UnZip(textures, path + "GPP_Textures/", path + "GPP_Textures/");
            }
        }
    }
}
