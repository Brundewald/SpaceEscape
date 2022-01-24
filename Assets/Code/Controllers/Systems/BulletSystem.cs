namespace SpaceEscape
{
    internal sealed class BulletSystem
    {
        private readonly BulletPullController _bulletPullController;
        private readonly BulletModel _bulletModel;
        private readonly BulletFactory _bulletFactory;
        private readonly BulletController _bulletController;

        public BulletPullController BulletPullController => _bulletPullController;

        public BulletModel BulletModel => _bulletModel;

        public BulletSystem(Controllers controllers, Data data, PlayerSystem playerSystem, CameraSystem cameraSystem)
        {
            _bulletModel = new BulletModel(data.Bullet);
            _bulletFactory = new BulletFactory(_bulletModel);
            _bulletPullController = new BulletPullController(_bulletFactory, playerSystem.GetPlayer(), _bulletModel.FirePointOffset);
            _bulletController = new BulletController(_bulletPullController, cameraSystem.CameraController);
            
            controllers.Add(_bulletPullController);
            controllers.Add(_bulletController);
        }
    }
}
