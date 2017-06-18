using UnityEngine;
using Kopernicus;
using Kopernicus.Configuration;
using Kopernicus.Components;


namespace GalacticNeighborhoodPlugin
{
    [ParserTargetExternal("Body", "ProceduralStar", "Kopernicus")]
    public class ProceduralStar : BaseLoader, IParserEventSubscriber
    {
        [ParserTarget("temperature", optional = true)]
        public NumericParser<int> temperature = 5772;

        [ParserTarget("emitColor1", optional = true)]
        public Texture2DParser emitColor1;

        [ParserTarget("emitColor0", optional = true)]
        public Texture2DParser emitColor0;

        [ParserTarget("sunspotColor", optional = true)]
        public Texture2DParser sunspotColor;

        [ParserTarget("lightColor", optional = true)]
        public Texture2DParser lightColors;

        [ParserTarget("emitColorMult", optional = true)]
        public NumericParser<float> emitColorMult = -1;

        [ParserTarget("rimColorMult", optional = true)]
        public NumericParser<float> rimColorMult = -1;

        [ParserTarget("setOrbit", optional = true)]
        public NumericParser<bool> setOrbit = true;

        [ParserTarget("type", optional = true)]
        public EnumParser<StarType> type = StarType.MainSequence;

        void IParserEventSubscriber.Apply(ConfigNode node)
        {
        }

        void IParserEventSubscriber.PostApply(ConfigNode node)
        {
            // Apply changes to the Material
            Material material = generatedBody.scaledVersion.GetComponent<Renderer>()?.sharedMaterial;

            if (material != null)
            {
                if (emitColor0 != null)
                {
                    Color color = Pick(emitColor0);
                    if (type == StarType.WhiteDwarf)
                        color = Color.white;

                    material.SetColor("_EmitColor0", color);

                    if (emitColorMult > 0 && emitColorMult < float.MaxValue)
                        material.SetColor("_EmitColor1", color * emitColorMult);

                    if (rimColorMult > 0 && rimColorMult < float.MaxValue)
                        material.SetColor("_RimColor", color * rimColorMult);
                }

                if (emitColor1 != null)
                    material.SetColor("_EmitColor1", Pick(emitColor1));

                if (sunspotColor != null)
                    material.SetColor("_SunspotColor", Pick(sunspotColor));
            }


            // Apply changes to the LightShifter
            LightShifter light = generatedBody.scaledVersion.GetComponentInChildren<LightShifter>();

            if (light != null && lightColors != null)
            {
                Color color = Pick(lightColors);

                light.ambientLightColor = new Color(0, 0, 0, 1);
                light.IVASunColor = color;
                light.scaledSunlightColor = color;
                light.sunlightColor = color;
            }


            // Set Orbit Color
            if (setOrbit.value && emitColor0 != null)
                generatedBody.orbitRenderer.SetColor(Pick(emitColor0));
        }

        Color Pick(Texture2D texture)
        {
            int x = (temperature - 2400) / 50;
            x = x < 0 ? 0 : x > texture.width - 1 ? texture.width - 1 : x;

            return texture.GetPixel(x, 0);
        }

        public enum StarType
        {
            MainSequence,
            WhiteDwarf,
            RedGiant
        }
    }
}
