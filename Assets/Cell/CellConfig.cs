using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Cell
{
    [CreateAssetMenu (fileName = "Configs", menuName = "Configs/CellConfig")]
    public class CellConfig : ScriptableObject
    {
        [SerializeField] private CellModel[] models;

        public CellModel GetModel(int id)
        {
            return models[id];
        }

        public int GetModelLengs()
        {
            return models.Length;
        }
    }

    [Serializable]
    public struct CellModel
    {
        public CellType CellType;
        public Sprite Sprite;
    }

    public enum CellType
    {
        Acorn,
        Amanita,
        Apple,
        Asparagus,
        avocado,
        Bananas,
        Becone,
        Beer,
        Beet,
        None
    }
}