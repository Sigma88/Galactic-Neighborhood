using UnityEngine;
using Kopernicus;
using Kopernicus.Configuration;
using System.Linq;
using System;


namespace GalacticNeighborhoodPlugin
{
    [ParserTargetExternal("Body", "ScaledVersion")]
    public class SettingsLoader : BaseLoader
    {
        [ParserTarget("Coronas", optional = true, allowMerge = true)]
        public CoronaFixer coronasFixer;

        [ParserTarget("Light", optional = true, allowMerge = true)]
        public ActiveFlareLoader activeFlareLoader;
    }

    public class ActiveFlareLoader : BaseLoader
    {
        [ParserTarget("activeSunFlare", optional = true)]
        public AssetParser<Flare> activeFlare
        {
            set
            {
                if (value.value != null && !SunFlareSwitcher.activeFlares.ContainsKey(generatedBody.name))
                    SunFlareSwitcher.activeFlares.Add(generatedBody.name, value.value);
            }
        }
    }

    public class CoronaFixer : BaseLoader
    {
        [ParserTarget("coronaTexture", optional = true, getAll = ",")]
        public StringCollectionParser coronaTextures
        {
            set
            {
                SunCoronas[] coronas = generatedBody.scaledVersion?.GetComponentsInChildren<SunCoronas>(true);

                for (int i = 0; i < Math.Min(coronas.Length, value.value.Count); i++)
                {
                    Material material = coronas[i]?.GetComponent<Renderer>()?.material;
                    Texture mainTexture = Resources.FindObjectsOfTypeAll<Texture>().FirstOrDefault(t => t.name == value.value[i]);
                    if (mainTexture != null && material != null)
                        material.mainTexture = mainTexture;
                }
            }
        }
    }
}
