using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPaint3D : MonoBehaviour
{
    public ParticleSystem system;

    void Start()
    {
        //// A simple particle material with no texture.
        //Material particleMaterial = new Material(Shader.Find("Particles/Standard Unlit"));

        //// Create a green Particle System.
        //var go = new GameObject("Particle System");
        //go.transform.Rotate(-90, 0, 0); // Rotate so the system emits upwards.
        //system = go.AddComponent<ParticleSystem>();
        //go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
        //var mainModule = system.main;
        //mainModule.startColor = Color.green;
        //mainModule.startSize = 0.5f;

        //// Every 2 secs we will emit.
        ////InvokeRepeating("DoEmit", 2.0f, 2.0f);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null)
                {
                    DoEmit(hit.point);
                }
            }
        }
    }

    void DoEmit(Vector3 posParticle)
    {
        // Any parameters we assign in emitParams will override the current system's when we call Emit.
        // Here we will override the start color and size.
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.startColor = Color.red;
        emitParams.startLifetime = 100000;
        emitParams.startSize = 0.1f;
        emitParams.velocity = Vector3.zero;
        emitParams.position = posParticle;
        system.Emit(emitParams, 1);
        system.Play(); // Continue normal emissions
    }
}
