 using Services.AssertService;
 using Services.StaticDataService;
 using UI.Services.Windows;
 using UnityEngine;

 namespace UI.Services.Factory
{
    public interface IUIFactory
    {
        void CreateEndGameWindow();
        void CreateUIRoot();
    }

    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/Prefabs/UIRoot.prefab";
        private IAsserts _asserts;
        private Transform uiRoot;
        private IStaticDataService _staticData;

        public UIFactory(IAsserts asserts)
        {
            _asserts = asserts;
        }


        public void CreateEndGameWindow()
        {
            var config = _staticData.ForWindow(WindowID.EndGame);
        }

        public void CreateUIRoot()
        {
            uiRoot = _asserts.Instantiate(UIRootPath).transform;
        }
    }
}