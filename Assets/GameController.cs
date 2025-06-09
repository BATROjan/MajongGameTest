using UI;
using UI.StartWindow;

namespace DefaultNamespace
{
    public class GameController
    {
        private readonly IUIService _uiService;
        public GameController(
            IUIService uiService)
        {
            _uiService = uiService;
            _uiService.Show<StartWindowView>();
        }
    }
}