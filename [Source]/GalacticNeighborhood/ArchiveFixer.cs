using UnityEngine;
using KSP.UI.Screens;

namespace SigmaBinaryPlugin
{
	namespace Configuration
	{
		[KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
		public class ArchivesFixer : MonoBehaviour
		{
			void Update()
			{
				foreach (RDPlanetListItemContainer planetItem in Resources.FindObjectsOfTypeAll<RDPlanetListItemContainer>())
				{
					if (planetItem.label_planetName.text == "MK1A" |
                        planetItem.label_planetName.text == "MK1B" |
                        planetItem.label_planetName.text == "MK1C" )
					{
						planetItem.gameObject.SetActive(false);
					}
				}
			}
		}
	}
}
