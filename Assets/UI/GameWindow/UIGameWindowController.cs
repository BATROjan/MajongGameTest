using DefaultNamespace.Path;
using UnityEngine;
using Zenject;

namespace UI.GameWindow
{
    public class UIGameWindowController
    {
        private GameWindowView _gameWindowView;
        private readonly PathController _pathController;
        private readonly IUIService _uiService;

        public UIGameWindowController(
            PathController pathController,
            IUIService uiService)
        {
            _pathController = pathController;
            _uiService = uiService;
            _gameWindowView = _uiService.Get<GameWindowView>();
            
            _gameWindowView.ShowAction += Show;
            // _uiStartWindow.HideAction += UnSubscribeButtons;
        }
        private void Show()
        {
            InitButtons();
        }

        private void InitButtons()
        {

        }

    }
}