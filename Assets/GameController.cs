using DefaultNamespace.Cell;
using DefaultNamespace.Grid;
using UI;
using UI.StartWindow;

namespace DefaultNamespace
{
    public class GameController
    {
        private readonly GridController _gridController;
        private readonly CellController _cellController;
        private readonly IUIService _uiService;
        public GameController(
            GridController gridController,
            CellController cellController,
            IUIService uiService)
        {
            _gridController = gridController;
            _cellController = cellController;
            _uiService = uiService;
            _uiService.Show<StartWindowView>();
            _gridController.SpawnGrid();
            _cellController.SpawnCells();
        }
    }
}