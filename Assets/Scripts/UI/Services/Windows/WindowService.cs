using UI.Services.Factory;

namespace UI.Services.Windows
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _iuiFactory;

        public WindowService(IUIFactory iuiFactory)
        {
            _iuiFactory = iuiFactory;
        }

        public void Open(WindowID window)
        {
            switch (window)
            {
                case WindowID.Unknown:
                    break;
                case WindowID.EndGame:
                   // _iuiFactory.CreateEndGameWindow();
                    break;
            }
        }
    }
}