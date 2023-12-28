using System;
using Controller;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class WelcomeView : ViewBase
    {
        private Image _backGroundImg;
        private Button _startButton;
        private ViewManager _viewManager;
        public override void Initialize(ViewManager viewManager)
        {
            _viewManager = viewManager;
            _startButton = transform.Find("StartButton").GetComponent<Button>();
            _startButton.onClick.AddListener(StartGame);
        }

        public override void EndUpView()
        {
            _startButton.onClick.RemoveAllListeners();
        }
        private void StartGame()
        {
            _viewManager.GoToGamePlayView();
        }
        
    }
}