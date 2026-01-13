
namespace CarAvoidGame.Domain
{
    public static class GameConstants
    {
        //All game parameters in one place
        public const int CarWidth = 50;    // Car dimensions
        public const int CarHeight = 80;
        public const int CarSpeed = 10;    //Lateral movement speed

        public const int ObstacleWidth = 50;  //Obstacle dimensions
        public const int ObstacleHeight = 80;
        public const int ObstacleMinSpeed = 4; //Random speed range
        public const int ObstacleMaxSpeed = 10;

        //Difficulty progression
        public const int InitialSpawnIntervalTicks = 25; //Slower at start
        public const int MinimumSpawnIntervalTicks = 8; //Maximum speed
        public const int SpawnIntervalDecreaseStep = 1; //How much faster per difficulty increase

        //Scoring system
        public const int ScorePerTick = 1; //Time-based scoring
        public const int ScorePerAvoidedObstacle = 10; //Bonus for passing obstacles
    }
}
