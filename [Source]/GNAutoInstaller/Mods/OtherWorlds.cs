using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class OtherWorlds : Pack<OtherWorlds>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Other Worlds Reboot 0.2.zip"; } }
        internal override string path { get { return "GameData/OtherWorldsReboot/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    "GameData/OtherWorldsReboot/OtherWorldsReboot/CercaniSystem/Clouds/",
                    "GameData/OtherWorldsReboot/OtherWorldsReboot/CercaniSystem/Scatterer/"
                };
            }
        }

        internal override bool Check()
        {
            if (Directory.Exists(path)) return true;

            return File.Exists(archive) && CTTP.Mod.Check();
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "OtherWorldsReboot/", path);

                CTTP.Mod.Install();
            }
        }
    }
}
