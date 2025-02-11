using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticleEffectManager : MonoBehaviour
{
    public GameObject praticleEmitterPrefab;
    private GameObject instance;

    // Start is called before the first frame update
    void Activate()
    {
        instance = Instantiate(praticleEmitterPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Desactivate()
    {
        Destroy(instance);
    }
}
