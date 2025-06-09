using UI.GameWindow;

namespace UI.StartWindow
{
    public class UIStartWindowController
    {
        private StartWindowView _uiStartWindow;
        private GameWindowView _gameWindowView;
        private readonly IUIService _uiService;

        public UIStartWindowController(
            IUIService uiService)
        {
            _uiService = uiService;
            _uiStartWindow = _uiService.Get<StartWindowView>();
            _gameWindowView = _uiService.Get<GameWindowView>();
            
            _uiStartWindow.ShowAction += Show;
           // _uiStartWindow.HideAction += UnSubscribeButtons;
        }
        private void Show()
        {
            InitButtons();
        }

        private void InitButtons()
        {
            _uiStartWindow.Buttons[0].OnClick += StartGame;

        }

        private void StartGame()
        {
            _gameWindowView.Show();
            _uiStartWindow.Hide();
            
            UISubscribeButtons();
        }

        private void UISubscribeButtons()
        {
            _uiStartWindow.Buttons[0].OnClick -= StartGame;
        }
    }
}