using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class RSS : Pack<RSS>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/RealSolarSystem_v12.0.zip"; } }
        internal override string path { get { return "GameData/RealSolarSystem/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                        "RealSolarSystem/Compatibility/",
                        "RealSolarSystem/Plugins/",
                        "RealSolarSystem/ResourceConfigs/",
                        "RealSolarSystem/ContractModifier.cfg",
                        "RealSolarSystem/DSN_Ranges.cfg",
                        "RealSolarSystem/LaunchSites.cfg",
                        "RealSolarSystem/PhysicsModifier.cfg",
                        "RealSolarSystem/RemoteTech_Settings.cfg",
                        "RealSolarSystem/ContractModifier.cfg",
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
                string[] filter = new string[]
                {
                };

                Archive.UnZip(archive, "RealSolarSystem/", path, filter);
                Archive.UnZip(archive, "RealSolarSystem/ResourceConfigs/Ore.cfg", path + "ResourceConfigs/Ore.cfg");
            }
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

        internal void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path);
            }
        }
    }
}
