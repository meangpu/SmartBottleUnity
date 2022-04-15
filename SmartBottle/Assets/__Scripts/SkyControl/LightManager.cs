using UnityEngine;

[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    // ref
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    // var
    [SerializeField, Range(0, 24)] private float TimeOfDay;

    private void OnValidate() 
    {
        if (DirectionalLight != null)
        {
            return;
        }
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
        
    }

    private void Update() 
    {
        if(Preset == null)
        {
            return;
        }
        if(Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 24;
            updateLight(TimeOfDay /24f);
        }
        else
        {
            updateLight(TimeOfDay /24f);
        }
    }

    void updateLight(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientCol.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogCol.Evaluate(timePercent);


        if (RenderSettings.skybox.HasProperty("_Top"))
        {
            RenderSettings.skybox.SetColor("_Top", Preset.upperCol.Evaluate(timePercent));
        }
        if (RenderSettings.skybox.HasProperty("_Bottom"))
        {
            RenderSettings.skybox.SetColor("_Bottom", Preset.lowerCol.Evaluate(timePercent));
        }



        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalCol.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent*360f) -90f, 170f, 0));
        }

    } 

}
