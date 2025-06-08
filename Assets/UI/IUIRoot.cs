using UnityEngine;

namespace Kolya_sGame.UI
{
    public interface IUIRoot
    {
        Transform ActivateContainer { get; }
        Transform DeativateContainer { get; }
        Canvas RootCanvas { get; }
    }
}