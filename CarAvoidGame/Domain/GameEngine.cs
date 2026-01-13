using System;
using System.Collections.Generic;
using System.Drawing;

namespace CarAvoidGame.Domain
{
    public sealed class GameEngine
    {
        private readonly Random _random;           // Random number generator
        private readonly List<Obstacle> _obstacles; // Active obstacles list
        private int _gameWidth;                     // Current game area width
        private int _gameHeight;                    // Current game area height  
        private int _spawnCounter;                  // Ticks since last obstacle spawn
        private int _spawnIntervalTicks;           // Current spawn rate (ticks between spawns)

        public int Health { get; private set; }    // Player health (100-0)
        public Car PlayerCar { get; private set; } // Player's car instance
        public IReadOnlyList<Obstacle> Obstacles => _obstacles; // Read-only view of obstacles
        public bool IsGameOver { get; private set; } // Game over flag
        public int Score { get; private set; }     // Current score

        public GameEngine(int gameWidth, int gameHeight)
        {
            _random = new Random();                    // Create random generator
            _obstacles = new List<Obstacle>();         // Initialize empty obstacle list
            ConfigureGameArea(gameWidth, gameHeight);  // Set game dimensions
            ResetGame();                               // Initialize game state
        }

        public void ConfigureGameArea(int gameWidth, int gameHeight)
        {
            _gameWidth = gameWidth;
            _gameHeight = gameHeight;
        }

        public void ResetGame()
        {
            Health = 100;                                 // Full health
            _obstacles.Clear();                           // Remove all obstacles
            Score = 0;                                    // Reset score
            IsGameOver = false;                           // Clear game over flag
            _spawnCounter = 0;                            // Reset spawn timer
            _spawnIntervalTicks = GameConstants.InitialSpawnIntervalTicks; // Easy start

            // Position car at bottom center
            int startX = (_gameWidth - GameConstants.CarWidth) / 2;
            int startY = _gameHeight - GameConstants.CarHeight - 10;
            PlayerCar = new Car(startX, startY, _gameWidth);
        }

        public void MoveCarLeft()
        {
            if (!IsGameOver) // Only allow movement if game is active
                PlayerCar.MoveLeft();
        }

        public void MoveCarRight()
        {
            if (!IsGameOver)
                PlayerCar.MoveRight();
        }

        public void Update()
        {
            if (IsGameOver)  // Don't update if game over
                return;

            Score += GameConstants.ScorePerTick;  // 1 point per tick

            MoveObstacles();          // Move all obstacles down
            RemoveOffscreenObstacles(); // Clean up + award points
            SpawnObstaclesIfNeeded();   // Create new obstacles
            CheckCollision();          // Detect car-obstacle collisions
            AdjustDifficulty();        // Make game harder
        }

        private void MoveObstacles()
        {
            foreach (var obstacle in _obstacles)
                obstacle.MoveDown();  // Each obstacle moves at its own speed
        }

        private void RemoveOffscreenObstacles()
        {
            int before = _obstacles.Count;

            // Remove obstacles whose top Y > gameHeight (completely off bottom)
            _obstacles.RemoveAll(o => o.Y > _gameHeight);

            int removed = before - _obstacles.Count;
            Score += removed * GameConstants.ScorePerAvoidedObstacle;
        }

        private void SpawnObstaclesIfNeeded()
        {
            _spawnCounter++;  // Increment tick counter

            if (_spawnCounter < _spawnIntervalTicks)  // Not time to spawn yet
                return;

            _spawnCounter = 0;  // Reset counter

            // Calculate how many lanes fit in game width
            int laneCount = Math.Max(_gameWidth / GameConstants.ObstacleWidth, 1);
            int laneIndex = _random.Next(0, laneCount);  // Pick random lane

            // Calculate X position aligned to lane grid
            int x = laneIndex * GameConstants.ObstacleWidth;

            // Random speed between 4-10
            int speed = _random.Next(GameConstants.ObstacleMinSpeed,
                                     GameConstants.ObstacleMaxSpeed + 1);

            // Spawn above screen (negative Y)
            _obstacles.Add(new Obstacle(x, -GameConstants.ObstacleHeight, speed));
        }

        private void CheckCollision()
        {
            Rectangle carBounds = PlayerCar.Bounds;

            // Iterate backwards (safe for removal during iteration)
            for (int i = _obstacles.Count - 1; i >= 0; i--)
            {
                Obstacle obstacle = _obstacles[i];

                if (obstacle.Bounds.IntersectsWith(carBounds))
                {
                    _obstacles.RemoveAt(i);  // Remove the hit obstacle
                    Health -= 25;            // Reduce health by 25%

                    if (Health <= 0)         // Check for game over
                    {
                        Health = 0;
                        IsGameOver = true;
                    }
                }
            }
        }


        private void AdjustDifficulty()
        {
            if (Score % 200 != 0)  // Every 200 points
                return;

            if (_spawnIntervalTicks > GameConstants.MinimumSpawnIntervalTicks)
                _spawnIntervalTicks -= GameConstants.SpawnIntervalDecreaseStep;
        }
    }
}
