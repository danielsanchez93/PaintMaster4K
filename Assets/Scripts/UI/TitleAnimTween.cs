using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleAnimTween : MonoBehaviour
{
    private void Start()
    {
        transform.DOScale(Vector3.one * 0.8f, 1).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
    }
}
