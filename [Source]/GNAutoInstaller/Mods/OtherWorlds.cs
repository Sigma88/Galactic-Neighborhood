using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class OtherWorlds : Pack<OtherWorlds>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Other Worlds Reboot 0.1.2.zip"; } }
        internal override string path { get { return "GameData/OtherWorldsReboot/"; } }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "OtherWorldsReboot/", "GameData/OtherWorldsReboot/");
            }
        }
    }
}
