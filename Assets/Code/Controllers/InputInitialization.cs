namespace SpaceEscape
{
    internal sealed class InputInitialization : IInitialization
    {
        private readonly IUserInputProxy _pcInputHorizontal;
        private readonly IUserInputProxy _pcInputVertical;
        private readonly IUserKeyInputProxy _pcInputFire;

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputFire = new PCInputFire();
        }

        public void Initialization()
        { 
        }

        public InputData GetInput()
        {
            var result = new InputData(_pcInputHorizontal, _pcInputVertical, _pcInputFire);
            return result;
        }
    }
}
