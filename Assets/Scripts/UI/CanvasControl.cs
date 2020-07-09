using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CanvasControl : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject panelEnd;
    public GameObject[] stars;

    private void Start()
    {
        foreach(GameObject star in stars)
        {
            star.transform.localScale = Vector3.zero;
        }
        panelEnd.transform.localScale = Vector3.zero;
    }

    public void AbrirPanelStart()
    {
        panelStart.transform.DOScale(Vector3.one,1);
    }

    public void CerrarPanelStart()
    {
        panelStart.transform.DOScale(Vector3.zero, 1);
    }

    public void AbrirPanelEnd(int starsNumber)
    {
        FindObjectOfType<EndMessages>().SetMessage(starsNumber);
        Sequence showStarsSequence = DOTween.Sequence();
        showStarsSequence.Append(panelEnd.transform.DOScale(Vector3.one, 1));
        //foreach(GameObject star in stars)
        //{
        //    showStarsSequence.Append(star.transform.DOScale(Vector3.one, 0.5f));
        //}
        for(int i = 0; i < starsNumber; i++)
        {
            showStarsSequence.Append(stars[i].transform.DOScale(Vector3.one, 0.5f));
        }
    }
    public void CerrarPanelEnd()
    {
        Sequence showStarsSequence = DOTween.Sequence();
        foreach(GameObject star in stars)
        {
            showStarsSequence.Append(star.transform.DOScale(Vector3.zero, 0.2f));
        }
        showStarsSequence.Append(panelEnd.transform.DOScale(Vector3.zero, 0.3f));
        showStarsSequence.OnComplete(() => FindObjectOfType<SceneController>().ResetScene());
    }

}
