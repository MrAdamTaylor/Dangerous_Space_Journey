using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.FX
{
    public class ButtonTween : MonoBehaviour
    {
        [SerializeField] private float _scaleTo;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        [SerializeField] private LoopType _loopType;
        
        private Tween _tween;
        
        private void OnEnable() => Play();
        private void OnDisable() => Kill();


        private void Play()
        {
             _tween = transform
                .DOScale(_scaleTo, _duration)
                .SetUpdate(true) //       Если true, то игнорирует остановку времени (time.scale)
                .SetLoops(-1, _loopType)
                .SetEase(_ease)
                .OnComplete(() => _tween = null);
        }                     
        
        private void Kill()     => _tween?.Kill();
    }
}