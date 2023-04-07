using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuExecuter : MonoBehaviour
    {
        [SerializeField] private Death _death;

        [SerializeField] private Button _restart;
        [SerializeField] private Button _exit;


        private void Start()
        {
            // On Die
            Observable
                .Merge(
                    _death.IsDead
                        .Where(v => v)
                        .Delay(TimeSpan.FromSeconds(3)),
                    
                    _death.IsDead
                        .Where(v => !v)
                )
                .Subscribe(v =>
                {
                    gameObject.SetActive(v);
                    Debug.Log("Hello, world!");
                })
                .AddTo(this);
            
            // TODO: _sceneController.ReloadScene()
            // On Restart
            _restart.OnClickAsObservable()
                .Subscribe(_ =>  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex))
                .AddTo(this);
            
            // On Exit
            _exit.OnClickAsObservable()
                .Subscribe(_ => Application.Quit())
                .AddTo(this);
        }
    }
}