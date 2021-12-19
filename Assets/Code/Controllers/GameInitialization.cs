﻿using UnityEngine;

namespace SpaceEscape
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            var mainCamera = Camera.main;

            var cameraController = new CameraController(mainCamera);
            var inputInitialization = new InputInitialization();
            //var playerModel = new PlayerModel(data.Player.PlayerSprite, data.Player.Speed, data.Player.Position, data.Player.Name);
            var bulletModel = new BulletModel(data.Bullet.BulletSprite, data.Bullet.Name, data.Bullet.FirePointOffset, data.Bullet.Speed, data.Bullet.Force);
            var playerModel = new PlayerModel(data.Player.PlayerPrefab, data.Player.Speed, data.Player.Position, data.Player.Name);
            var playerFactory = new PlayerFactory(playerModel);
            var bulletFactory = new BulletFactory(bulletModel);
            var playerInitialization = new PlayerInitialization(playerFactory, playerModel.Position);
            var bulletPullController = new BulletPullController(bulletFactory, playerInitialization.GetPlayer(), bulletModel.FirePointOffset);
            var bulletController = new BulletController(bulletPullController, cameraController);
            var fireController = new FireController(bulletPullController, bulletModel);
            var enemyFactory = new EnemyFactory();

            controllers.Add(cameraController);
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(bulletPullController);
            controllers.Add(bulletController);
            controllers.Add(fireController);
            //controllers.Add(new EnemiesController(enemyFactory, data.Level, data.Enemies));
            controllers.Add(new EnemiesController(enemyFactory, data));

            controllers.Add(new InputController(playerInitialization.GetPlayer(), inputInitialization.GetInput(), fireController));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), playerModel, cameraController));
        }
    }
}