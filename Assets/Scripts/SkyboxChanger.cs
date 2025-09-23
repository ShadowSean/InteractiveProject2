using UnityEngine;
using UnityEngine.Playables;

public class SkyboxChanger : MonoBehaviour
{
    private Material skyboxMaterial;
    public Light lighting;
    float H, S, V;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        skyboxMaterial = RenderSettings.skybox;
        Color.RGBToHSV(skyboxMaterial.GetColor("_Tint"), out H, out S, out V);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        H += 0.002f;
        Debug.Log("H " + H + " S " + S + " V " + V);
        if (H >= 1f) H = 0;
        Color c = Color.HSVToRGB(H, S, V);
        skyboxMaterial.SetColor("_Tint",c); 
        lighting.color = c;

        // RenderSettings.skybox = skyboxMaterial;
    }
}
