﻿using System;
using DefaultNamespace.Grid;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace.Cell
{
    public class CellView : MonoBehaviour, IPointerClickHandler
    {
        public Action<CellView> OnCellSelected;
        public CellType CellType 
        {
            get
            {
                return _cellType;
            }
            set
            {
                _cellType = value;
            }
        }        
        public GridCellView ParentGridCellView 
        {
            get
            {
                return _parentGridCellView;
            }
            set
            {
                _parentGridCellView = value;
            }
        }
        public Image BlackOut => blackOut;
        public Image CellImage
        {
            get
            {
                return cellImage;
            }
            set
            {
                cellImage = value;
            }
        }
       [SerializeField] private Image cellImage;
       [SerializeField] private Image blackOut;
       private CellType _cellType;
       private GridCellView _parentGridCellView;

       private void DespawnItem(CellView item)
       {
          _cellType = CellType.None;
          cellImage.sprite = null;
          blackOut.gameObject.SetActive(true);
          _parentGridCellView = null;
       }
        public class  Pool : MonoMemoryPool<CellView>
        {
            protected override void OnDespawned(CellView item)
            {
                base.OnDespawned(item);
                item.DespawnItem(item);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnCellSelected?.Invoke(this);
        }
    }
}