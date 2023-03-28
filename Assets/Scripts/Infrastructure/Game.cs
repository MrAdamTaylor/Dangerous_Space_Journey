using Services.BorderService;
using Services.Input;
using Services.Input2;
using UnityEngine;

namespace Infrastructure
{
    class Game
    {
        public static IInputService InputService
        { get; set; }

        public static IInputService2 InputService2
        {
            get;
            set;
        }

        public static IBorderChecker BorderService;

        public Game()
        {
            RegisterInputService();
            RegisterBorderService();
        }

        private void RegisterBorderService()
        {
            BorderService = new BorderChecker();
        }

        private void RegisterInputService()
        {
            if (Application.isEditor)
            {
                InputService2 = new InputService2Impl();
            }
            else
            {
                InputService2 = new InputService2Impl();
            }

            /*if (Application.isEditor)
                InputService = new InputServiceImpl();
            else
                InputService = new InputServiceImpl();*/
        }
    }
}