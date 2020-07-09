using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PaintBrush : MonoBehaviour
{
    [SerializeField]
    private float BrushSize = 0.1f;
    public GameObject Brush;
    public SpriteRenderer color1, color2;
    public Slider brushsizeSlider;
    public Image actualColor;
    public ParticleSystem system;

    private int particleCount;
    private TimeController timeController;

    private void Start()
    {
        timeController = FindObjectOfType<TimeController>();
    }
    private void Update ()
    {
        //if(Input.GetMouseButton(0) )
        //{
        //    var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if(Physics.Raycast(Ray, out hit))
        //    {
        //        if(hit.collider != null)
        //        {
        //            //instanciate a brush
        //            var go = Instantiate(Brush, hit.point + Vector3.left * 0.1f, Quaternion.FromToRotation(Vector3.forward, hit.normal), transform);
        //            go.transform.localScale = Vector3.one * BrushSize;
        //            //go.transform.localRotation = Quaternion.Euler(0, 0, 0);
        //            go.GetComponent<SpriteRenderer>().color = CalculateMixedColor(color1.color,color2.color);
        //        }
        //    }
        //}

        actualColor.color = CalculateMixedColor(color1.color,color2.color);

        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null && hit.collider.CompareTag("Drawable"))
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
        emitParams.startColor = CalculateMixedColor(color1.color,color2.color);
        emitParams.startLifetime = 100000;
        emitParams.startSize = BrushSize;
        emitParams.velocity = Vector3.zero;
        emitParams.position = posParticle;
        system.Emit(emitParams, 1);
        system.Play();
        SendScore(1);
    }

    public void ChangeBrushSize()
    {
        BrushSize = brushsizeSlider.value;
    }

    private void SendScore(int points)
    {
        timeController.GetParticleCount(points);
    }

    private Color CalculateMixedColor(Color colorA, Color colorB)
    {
        Color mixedColor = (colorA + colorB) / 2;
        actualColor.color = mixedColor;
        return mixedColor;
    }

    ///DISABLED IN ORDER TO SKIP THE EXTRA CAMERA USE
    //public void Save()
    //{
    //    StartCoroutine(CoSave());
    //}


    //private IEnumerator CoSave()
    //{
    //    //wait for rendering
    //    yield return new WaitForEndOfFrame();
    //    Debug.Log(Application.dataPath + "/savedImage.png");

    //    //set active texture
    //    RenderTexture.active = RTexture;

    //    //convert rendering texture to texture2D
    //    var texture2D = new Texture2D(RTexture.width, RTexture.height);
    //    texture2D.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
    //    texture2D.Apply();

    //    //write data to file
    //    var data = texture2D.EncodeToPNG();
    //    File.WriteAllBytes(Application.dataPath + "/savedImage.png", data);


    //}
}
