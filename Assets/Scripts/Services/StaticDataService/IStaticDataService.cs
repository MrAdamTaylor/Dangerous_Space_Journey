using UI.Services.Factory;
using UI.Services.Windows;

namespace Services.StaticDataService
{
    public interface IStaticDataService
    {
        WindowConfig ForWindow(WindowID wind);
    }
}