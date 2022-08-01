using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


    public enum UIAnimationTypes
    {
        Move,
        Scale,
        ScaleX,
        ScaleY,
        Fade
    }

public class UITweener : MonoBehaviour
{
    public GameObject objctToAnimate;

    public UIAnimationTypes animationType;
    public LeanTweenType easeType;
    public float duration;
    public float delay;

    public bool loop;
    public bool pingpong;

    public bool startPositionOffset;
    public Vector3 from;
    public Vector3 to;

    private LTDescr _tweenObject;

    public bool showOnEnable;
    public bool workOnDisable;

    public void OnEnable()
    {
        if (showOnEnable)
        {
            Show();
        }
    }

    public void Show()
    {
        HandleTween();
    }
    public void HandleTween()
    {
        if (objctToAnimate == null)
        {
            objctToAnimate = gameObject;
        }
        switch (animationType)
        {
            case UIAnimationTypes.Fade:
                Fade();
                break;
            case UIAnimationTypes.Move:
                MoveAbsolute();
                break;
            case UIAnimationTypes.Scale:
                Scale();
                break;
            case UIAnimationTypes.ScaleX:
                Scale();
                break;
            case UIAnimationTypes.ScaleY:
                Scale();
                break;
        }
        _tweenObject.setDelay(delay);
        _tweenObject.setEase(easeType);
        if (loop)
        {
            _tweenObject.loopCount = int.MaxValue;
        }
        if (pingpong)
        {
            _tweenObject.setLoopPingPong();
        }
    }

    public void Fade()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();
        }

        if (startPositionOffset)
        {
            objctToAnimate.GetComponent<CanvasGroup>().alpha = from.x;
        }
        _tweenObject = LeanTween.alphaCanvas(objctToAnimate.GetComponent<CanvasGroup>(), to.x, duration);
    }
    public void MoveAbsolute()
    {
        objctToAnimate.GetComponent<RectTransform>().anchoredPosition = from;
        _tweenObject = LeanTween.move(objctToAnimate.GetComponent<RectTransform>(), to, duration);
    }
    public void Scale()
    {
        if (startPositionOffset)
        {
            objctToAnimate.GetComponent<RectTransform>().localScale = from;
        }
        _tweenObject = LeanTween.scale(objctToAnimate, to, duration);
    }

    void SwapDirection()
    {
        var temp = from;
        from = to;
        to = temp;
    }
    public void Disable()
    {
        SwapDirection();
        HandleTween();
        _tweenObject.setOnComplete(() =>
        {
            SwapDirection();
            gameObject.SetActive(false);
        });
    }

   

}
