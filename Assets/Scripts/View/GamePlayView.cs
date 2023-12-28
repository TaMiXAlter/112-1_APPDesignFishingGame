using Controller;
using UnityEngine.UI;

namespace View
{
    public class GamePlayView : ViewBase
    {
        private ViewManager _viewManager;
        private Button shopButton, equipmentButton, gaChaButton;
        public override void Initialize(ViewManager viewManager)
        {
            _viewManager = viewManager;
            shopButton = transform.Find("ShopButton").GetComponent<Button>();
            equipmentButton = transform.Find("EquipmentButton").GetComponent<Button>();
            gaChaButton = transform.Find("GaChaButton").GetComponent<Button>();
        
            shopButton.onClick.AddListener(_viewManager.GoToShopView);
            equipmentButton.onClick.AddListener(_viewManager.GoToEquipmentView);
            gaChaButton.onClick.AddListener(_viewManager.GoTOGaChaView);
        }

        public override void EndUpView()
        {
            shopButton.onClick.RemoveAllListeners();
            equipmentButton.onClick.RemoveAllListeners();
            gaChaButton.onClick.RemoveAllListeners();
        }
    }
}
