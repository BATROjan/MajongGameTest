namespace UI.GameWindow
{
    public class UIGameWindowController
    {
        private GameWindowView _gameWindowView;
        private readonly IUIService _uiService;

        public UIGameWindowController(
            IUIService uiService)
        {
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