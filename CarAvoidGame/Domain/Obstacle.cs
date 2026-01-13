namespace CarAvoidGame.Domain
{
    // Game obstacle that player must avoid
    public sealed class Obstacle : GameObject
    {
        public int FallSpeed { get; }  // Vertical movement speed

        // Creates obstacle at position with speed
        public Obstacle(int x, int y, int fallSpeed)
            : base(x, y, GameConstants.ObstacleWidth, GameConstants.ObstacleHeight)
        {
            FallSpeed = fallSpeed;  // Store the falling speed for this obstacle
        }

        // Move obstacle down the screen
        public void MoveDown()
        {
            Y += FallSpeed;
        }
    }
}