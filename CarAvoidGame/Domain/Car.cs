

namespace CarAvoidGame.Domain
{
    public sealed class Car : GameObject
    {
        private readonly int _gameWidth;

        public int Speed { get; }

        public Car(int startX, int startY, int gameWidth)
            : base(startX, startY, GameConstants.CarWidth, GameConstants.CarHeight)
        {
            _gameWidth = gameWidth;
            Speed = GameConstants.CarSpeed;
        }

        public void MoveLeft()
        {
            int newX = X - Speed;          // Calculate new position
            if (newX < 0)                  // Check left boundary
                newX = 0;                  // Clamp to 0 (left edge)
            X = newX;                      // Update position
        }

        public void MoveRight()
        {
            int maxX = _gameWidth - Width;  // Rightmost allowed position
            int newX = X + Speed;           // Calculate new position
            if (newX > maxX)                // Check right boundary
                newX = maxX;                // Clamp to maxX
            X = newX;                       // Update position
        }
    }
}
