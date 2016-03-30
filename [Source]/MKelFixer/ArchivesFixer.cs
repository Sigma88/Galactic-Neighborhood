using System.Collections.Generic;
using UnityEngine;
using SigmaGalacticNeighborhood.Components;
using SigmaGalacticNeighborhood.Configuration;
using System;
using System.Reflection;
using System.Linq;

namespace SigmaGalacticNeighborhood
{
	namespace Configuration
	{
		[KSPAddon(KSPAddon.Startup.SpaceCentre, true)]
		public class ArchivesFixer : MonoBehaviour
		{
			void Update()
			{
				foreach (RDPlanetListItemContainer planetItem in Resources.FindObjectsOfTypeAll<RDPlanetListItemContainer>())
				{
					if (MKelLoader.ArchivesFixerList.Contains(planetItem.label_planetName.text))
					{
                        planetItem.gameObject.SetActive(false);
                    }
				}
			}
		}
	}
}
