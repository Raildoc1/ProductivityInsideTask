using PITask.Character;
using PITask.Input;

namespace PITask.Player
{
    public class PlayerShootingController
    {
        private IPlayerInputHandler _inputHandler;
        private CharacterShooter _characterShooter;

        public void Init(CharacterShooter characterShooter, IPlayerInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            _characterShooter = characterShooter;

            _inputHandler.Fire += Shoot;
        }

        public void Deinit()
        {
            _inputHandler.Fire -= Shoot;
        }

        private void Shoot() => _characterShooter.Shoot();
    }
}