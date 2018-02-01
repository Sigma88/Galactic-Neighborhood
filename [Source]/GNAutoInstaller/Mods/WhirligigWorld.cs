/*using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class WhirligigWorld : Pack<WhirligigWorld>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/WhirligigWorld.zip"; } }
        internal override string path { get { return "GameData/WhirligigWorld/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    "WhirligigWorld/ModCompatibility/Clouds/",
                    "WhirligigWorld/Patches/"
                };
            }
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, "WhirligigWorld/", path, filter);
            }
        }
    }
}
*/