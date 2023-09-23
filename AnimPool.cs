using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class AnimPool : MonoBehaviour
{
    public List<RectTransform> objects = new List<RectTransform>();
    [Header ("Ajustes (1)")]
    public LeanTweenType inOutType;
    public float duration;
    public float delay = 0;
    [Space(20)]
    [Header("Posicion Inicial (2)")]
    public Vector3 escalaInicial = new Vector3(0f, 0f, 0f);
    [Space (20)]
    [Header("Posicion Final (3)")]
    public Vector3 escalaFinal = new Vector3(1f, 1f, 1f);

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var obj = transform.GetChild(i).GetComponent<RectTransform>();
            objects.Add(obj);
            obj.localScale = new Vector3(escalaInicial.x,escalaInicial.y,escalaInicial.z);
            delay += 0.02f;
            MoveScale(obj,delay);
        }
    }
    public void MoveScale(RectTransform rect,float delay)
    {
        LeanTween.scale(rect, escalaFinal, duration).setDelay(delay).setEase(inOutType);
    }
}
