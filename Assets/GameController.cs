using DefaultNamespace.Cell;
using DefaultNamespace.Grid;
using DefaultNamespace.Path;
using UI;
using UI.GameWindow;
using UI.StartWindow;

namespace DefaultNamespace
{
    public class GameController
    {
        private readonly PathController _pathController;
        private readonly GridController _gridController;
        private readonly IUIService _uiService;

        private GameWindowView _gameWindowView;
        public GameController(
            PathController pathController,
            GridController gridController,
            IUIService uiService)
        {
            _pathController = pathController;
            _gridController = gridController;
            _uiService = uiService;
            
            _uiService.Show<StartWindowView>();
            _gameWindowView = _uiService.Get<GameWindowView>();
            _gameWindowView.ShowAction += StartGame;
        }

        private void StartGame()
        {
            _gridController.SpawnGrid();
            _pathController.SpawnPath();
        }
    }
}