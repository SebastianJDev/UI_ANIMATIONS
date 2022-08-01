using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ScaleTween : MonoBehaviour
{
    public LeanTweenType inType;
    public LeanTweenType outType;
    public float duration;
    public float delay;
    public UnityEvent onCompleteCallback;

    public void OnEnable()
    {
        transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(gameObject, new Vector3(2, 2, 2), duration).setDelay(delay).setEase(inType).setOnComplete(OnComplete);
    }
    public void OnComplete()
    {
        if(onCompleteCallback != null)
        {
            onCompleteCallback.Invoke();
        }
    }



    public void OnClose()
    {
        //LeanTween.scale(gameObject,new Vector3(0,0,0), 0.5f).setOnComplete(DestroyMe);
        LeanTween.moveX(gameObject, -1500, duration).setDelay(delay).setEase(outType).setOnComplete(DestroyMe);
    }
    void DestroyMe()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
        

    }
}
