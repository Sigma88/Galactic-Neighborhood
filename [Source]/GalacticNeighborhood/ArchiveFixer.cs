using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using KSP.UI.Screens;



namespace GalacticNeighborhoodPlugin
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class ArchivesFixerComponent : MonoBehaviour
    {
        void Update()
        {
            if (HighLogic.LoadedScene == GameScenes.SPACECENTER)
            {
                foreach (RDArchivesController item in Resources.FindObjectsOfTypeAll<RDArchivesController>())
                    item.gameObject.AddOrGetComponent<ArchivesFixer>();
            }
        }
    }

    public class ArchivesFixer : MonoBehaviour
    {
        void Start()
        {
            PSystemBody parent = PSystemManager.Instance.systemPrefab.GetComponentsInChildren<PSystemBody>(true).First(b => b.name == "M-Kel");
            parent.children.Clear();

            foreach (string star in new[] { "M-Kel A", "M-Kel B", "M-Kel C" })
            {
                parent.children.Add(PSystemManager.Instance.systemPrefab.GetComponentsInChildren<PSystemBody>(true).First(b => b.name == star));
            }
            
            FieldInfo list = typeof(RDArchivesController).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Skip(7).First();
            MethodInfo add = typeof(RDArchivesController).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Skip(27).First();
            var RDAC = Resources.FindObjectsOfTypeAll<RDArchivesController>().First();
            
            list.SetValue(RDAC, new Dictionary<string, List<RDArchivesController.Filter>>());
            
            add.Invoke(RDAC, null);
        }
    }
}
