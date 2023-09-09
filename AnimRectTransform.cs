using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AnimRectTransform : MonoBehaviour
{
    private RectTransform rectTransform;
    [Space(20)]
    [Header("Ajustes (1)")]
    public LeanTweenType inType;
    public LeanTweenType outType;
    public float duration;
    public float delay;
    [Space(20)]
    [Header("Posicion Inicial (2)")]
    public Vector3 escalaIncial = new Vector3 (0f, 0f, 0f);
    public Vector3 transformInicial = new Vector3(0f, 0f, 0f);
    [Space(20)]
    [Header("Pocision Final (3)")]
    public Vector3 escalaFinal = new Vector3(1f, 1f, 1f);
    public Vector3 transformFinal = new Vector3(0f, 0f, 0f);
    public enum TipoMovimiento
    {
        MovTrans,
        MoveScale
    }
    [Space(20)]
    [Header("Tipo de movimiento (4)")]
    public TipoMovimiento CanMove;
    [Space(20)]
    [Header("OnComplete (5)")]
    [Space(10)]
    public UnityEvent onCompleteCallback;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnEnable()
    {
        switch (CanMove)
        {
            case TipoMovimiento.MoveScale:
                rectTransform.localScale = new Vector3(escalaIncial.x, escalaIncial.y, escalaIncial.z);
                MoveScale();
                break;
            case TipoMovimiento.MovTrans:
                rectTransform.position = new Vector3(transformInicial.x, transformInicial.y, transformInicial.z);
                MoveTransform();
                break;
        }
    }

    public void MoveScale()
    {
        LeanTween.scale(rectTransform, escalaFinal, duration).setDelay(delay).setEase(inType).setOnComplete(OnComplete);
    }
    public void MoveTransform()
    {
        LeanTween.move(rectTransform,transformFinal,duration).setDelay(delay).setEase(inType).setOnComplete(OnComplete);
    }
    public void OnComplete()
    {
        if (onCompleteCallback != null)
        {
            onCompleteCallback.Invoke();
        }
    }
}
