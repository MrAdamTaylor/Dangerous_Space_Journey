using Services.BorderService;
using Services.Input;
using UnityEngine;

namespace Infrastructure
{
    class Game
    {

        public static IInputServiceMove InputServiceMove
        {
            get;
            set;
        }

        public static IBorderChecker BorderService;
        public static ISpecialEffectService SpecialEffectService;

        public static IInputServiceShoot InputServiceShoot { get; set; }

        public Game()
        {
            RegisterInputService();
            RegisterBorderService();
            RegisterShootService();
            RegisterSpecialEffectService();
        }

        private void RegisterSpecialEffectService()
        {
            SpecialEffectService = new SpecialEffectService();
        }

        private void RegisterShootService()
        {
            if (Application.isEditor)
            {
                InputServiceShoot = new InputServiceShootImpl();
            }
            else
            {
                InputServiceShoot = new InputServiceShootImpl();
            }
        }

        private void RegisterBorderService()
        {
            BorderService = new BorderChecker();
        }

        private void RegisterInputService()
        {
            if (Application.isEditor)
            {
                InputServiceMove = new InputServiceMoveImpl();
            }
            else
            {
                InputServiceMove = new InputServiceMoveImpl();
            }
            
        }
    }
}