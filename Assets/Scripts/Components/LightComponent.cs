using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightComponent : MonoBehaviour
{
    public Light _light;

    private float intensity;
    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
        intensity = _light.intensity;
        _light.intensity = 0;
    }

    // Update is called once per frame
    public void Interact(GameObject instigator)
    {
        if (_light.intensity == 0f)
        {
            _light.intensity = intensity;
        }
        else
        {
            _light.intensity = 0f;
        }
        
    }
}
