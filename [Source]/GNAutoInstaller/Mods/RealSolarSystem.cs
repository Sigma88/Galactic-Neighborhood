using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class RSS : Pack<RSS>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/RealSolarSystem_v16.2.zip"; } }
        internal override string path { get { return "GameData/RealSolarSystem/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "Compatibility/",
                    path + "Plugins/",
                    path + "ResourceConfigs/",
                    path + "ContractModifier.cfg",
                    path + "DSN_Ranges.cfg",
                    path + "LaunchSites.cfg",
                    path + "PhysicsModifier.cfg",
                    path + "RemoteTech_Settings.cfg",
                    path + "RSS_TerrainDetailPresets.cfg",
                    path + "ScienceDefs.cfg"
                };
            }
        }

        internal override bool Check()
        {
            if (SD.Check() && !SASS.Mod.Check() && RSSTextures.Check())
            {
                return File.Exists(archive) || Directory.Exists(path);
            }

            return false;
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path, filter);
                Archive.UnZip(archive, path + "ResourceConfigs/Ore.cfg", path + "ResourceConfigs/Ore.cfg");
            }

            RSSTextures.Install();
        }
    }

    class RSSTextures
    {
        static string archive = "PluginData/GalacticNeighborhood/";
        static string path = "GameData/RSS-Textures/";

        internal static bool Check()
        {
            if (SD.Check())
            {
                if (!Directory.Exists(path))
                {
                    archive = "PluginData/GalacticNeighborhood/";
                    if (File.Exists(archive + "2048.zip"))
                        archive += "2048.zip";
                    else if (File.Exists(archive + "4096.zip"))
                        archive += "4096.zip";
                    else if (File.Exists(archive + "8192.zip"))
                        archive += "8192.zip";
                    else return false;
                }
                return true;
            }
            return false;
        }

        internal static void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "RSS-Textures/", path);
            }
        }
    }
}
