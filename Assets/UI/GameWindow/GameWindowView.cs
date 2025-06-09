using UnityEngine;

namespace UI.GameWindow
{
    public class GameWindowView : UIWindow
    {
        public UIButton[] Buttons => buttons;
        
        [SerializeField] private UIButton[] buttons;

        public override void Show()
        {
            ShowAction?.Invoke();
        }

        public override void Hide()
        {
            HideAction?.Invoke();
        }
    }
}