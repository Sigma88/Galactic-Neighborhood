using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class RealAsteroids : Pack<RealAsteroids>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/RealAsteroidsv1.2.zip"; } }
        internal override string path { get { return "GameData/RealExpansion/"; } }

        internal override bool Check()
        {
            if (RSS.Mod.Check())
            {
                return File.Exists(archive) || File.Exists(path + "Installed/RealAsteroids.txt");
            }

            return false;
        }

        internal override void Install()
        {
            if (!File.Exists(path + "Installed/RealAsteroids.txt"))
            {
                Archive.UnZip(archive, "RealExpansion", path, filter);
                Archive.UnZip(archive, "REx-Textures", "GameData/REx-Textures");
                Directory.CreateDirectory(path + "Installed/");
                File.WriteAllText(path + "Installed/RealAsteroids.txt", "RealAsteroids v1.1 has been installed using GNAutoInstaller");
            }
        }
    }

    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class RealMoons : Pack<RealMoons>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/RealMoonsv1.1.zip"; } }
        internal override string path { get { return "GameData/RealExpansion/"; } }

        internal override bool Check()
        {
            if (RSS.Mod.Check())
            {
                return File.Exists(archive) || File.Exists(path + "Installed/RealMoons.txt");
            }

            return false;
        }

        internal override void Install()
        {
            if (!File.Exists(path + "Installed/RealMoons.txt"))
            {
                Archive.UnZip(archive, "RealExpansion", path, filter);
                Archive.UnZip(archive, "REx-Textures", "GameData/REx-Textures");
                Directory.CreateDirectory(path + "Installed/");
                File.WriteAllText(path + "Installed/RealMoons.txt", "RealMoons v1.1 has been installed using GNAutoInstaller");
            }
        }
    }

    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class RealTNOs : Pack<RealTNOs>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/RealTNOsv1.3.zip"; } }
        internal override string path { get { return "GameData/RealExpansion/"; } }

        internal override bool Check()
        {
            if (RSS.Mod.Check())
            {
                return File.Exists(archive) || File.Exists(path + "Installed/RealTNOs.txt");
            }

            return false;
        }

        internal override void Install()
        {
            if (!File.Exists(path + "Installed/RealTNOs.txt"))
            {
                Archive.UnZip(archive, "RealExpansion", path, filter);
                Archive.UnZip(archive, "REx-Textures", "GameData/REx-Textures");
                Directory.CreateDirectory(path + "Installed/");
                File.WriteAllText(path + "Installed/RealTNOs.txt", "RealTNOs v1.3 has been installed using GNAutoInstaller");
            }
        }
    }
}
