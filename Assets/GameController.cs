using DefaultNamespace.Cell;
using DefaultNamespace.Grid;
using DefaultNamespace.Path;
using UI;
using UI.GameWindow;
using UI.StartWindow;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class GameController: ITickable
    {
        private readonly PathController _pathController;
        private readonly GridController _gridController;
        private readonly CellController _cellController;
        private readonly IUIService _uiService;
        private readonly TickableManager _tickableManager;

        public GameController(
            PathController pathController,
            GridController gridController,
            CellController cellController,
            IUIService uiService,
            TickableManager tickableManager)
        {
            _pathController = pathController;
            _gridController = gridController;
            _cellController = cellController;
            _uiService = uiService;
            _tickableManager = tickableManager;
            _tickableManager.Add(this);
            
            _uiService.Show<StartWindowView>();
            _gridController.SpawnGrid();
            _cellController.SpawnCells();
        }


        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _gridController.DeletCellFromClosenList(
                    _uiService.Get<GameWindowView>().DeleteCellView, 
                    _uiService.Get<GameWindowView>().TargetCellView); 
            }
        }
    }
}