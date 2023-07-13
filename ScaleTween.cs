using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace Root
{
    public class ScaleTween : MonoBehaviour
    {
        public LeanTweenType inType;
        public LeanTweenType outType;
        public float duration;
        public float delay;
        public UnityEvent onCompleteCallback;
        public Vector3 escala = new Vector3(1f,1f,1f);

        public void OnEnable()
        {
            transform.localScale = new Vector3(0, 0, 0);
            LeanTween.scale(gameObject, new Vector3(escala.x, escala.y, escala.z), duration).setDelay(delay).setEase(inType).setOnComplete(OnComplete);
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
}
