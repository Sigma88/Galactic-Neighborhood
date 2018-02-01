using System.Linq;


namespace GNAutoInstallerPlugin
{
    class SD
    {
        internal static bool Check()
        {
            return AssemblyLoader.loadedAssemblies.FirstOrDefault(a => a.name == "SigmaDimensions") != null;
        }
    }
}
