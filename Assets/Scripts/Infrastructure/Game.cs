using AbstractFactory;
using Services.AssertService;
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
        public static IAsserts AssertsService { get; set; }
        public static ISpawnerFactory Factory;

        public static IInputServiceShoot InputServiceShoot { get; set; }

        public Game()
        {
            RegisterInputService();
            RegisterBorderService();
            RegisterShootService();
            RegisterSpecialEffectService(); //TODO это надо будет убрать
            RegisterAssertService();
            RegisterAbstractFabric();
        }

        private void RegisterAbstractFabric()
        {
            Factory = new LocalSpawnerFactory(AssertsService);
        }

        private void RegisterAssertService()
        {
            AssertsService = new Asserts();
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