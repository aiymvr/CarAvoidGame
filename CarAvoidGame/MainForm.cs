using CarAvoidGame.Domain;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarAvoidGame
{
    public partial class MainForm : Form
    {
        private GameEngine _gameEngine;      // Core game logic
        private Image _backgroundImage;      // Road background
        private Image _carImage;             // Player car sprite
        private Image _obstacleImage;        // Obstacle cone sprite

        public MainForm()
        {
            InitializeComponent();
        }

        // Enable double buffering to prevent flickering
        private void EnableDoubleBuffering(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        // Form load event - initialize game
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeGameEngine();

            // Load game assets
            _backgroundImage = Image.FromFile("Images/road.png");
            _carImage = Image.FromFile("Images/car.png");
            _obstacleImage = Image.FromFile("Images/cone.png");

            EnableDoubleBuffering(panelGameArea);  // Smooth graphics
        }

        // Create game engine with current panel size
        private void InitializeGameEngine()
        {
            int gameWidth = panelGameArea.ClientSize.Width;
            int gameHeight = panelGameArea.ClientSize.Height;

            _gameEngine = new GameEngine(gameWidth, gameHeight);
            UpdateScoreLabel();
        }

        // Start/Restart game button
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (_gameEngine == null)
            {
                InitializeGameEngine();
            }
            progressHealth.Value = 100;  // Reset health bar

            _gameEngine.ResetGame();      // Reset game state
            gameTimer.Enabled = true;     // Start game loop
            Focus();                      // Get keyboard focus
            InvalidateGameArea();         // Redraw screen
        }

        // Move car left (button)
        private void buttonMoveLeft_Click(object sender, EventArgs e)
        {
            _gameEngine?.MoveCarLeft();   // Null-safe call
            InvalidateGameArea();         // Update display
        }

        // Move car right (button)
        private void buttonMoveRight_Click(object sender, EventArgs e)
        {
            _gameEngine?.MoveCarRight();
            InvalidateGameArea();
        }

        // Game loop - called every 40ms (25 FPS)
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (_gameEngine == null)
                return;

            progressHealth.Value = _gameEngine.Health;  // Update health bar

            _gameEngine.Update();         // Update game state
            UpdateScoreLabel();           // Update score display
            InvalidateGameArea();         // Redraw graphics

            // Check for game over
            if (_gameEngine.IsGameOver)
            {
                gameTimer.Enabled = false;  // Stop game loop
                MessageBox.Show(
                    $"Game Over! Final Score: {_gameEngine.Score}",
                    "Car Avoid Game",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // Paint event - render game graphics
        private void panelGameArea_Paint(object sender, PaintEventArgs e)
        {
            if (_gameEngine == null)
                return;

            // Render in order: background -> car -> obstacles
            DrawBackground(e.Graphics);
            DrawCar(e.Graphics);
            DrawObstacles(e.Graphics);
        }

        // Draw road background
        private void DrawBackground(Graphics graphics)
        {
            if (_backgroundImage != null)
            {
                // Stretch background to fill panel
                graphics.DrawImage(_backgroundImage,
                    new Rectangle(0, 0, panelGameArea.ClientSize.Width, panelGameArea.ClientSize.Height));
            }
            else
            {
                // Fallback: solid color
                graphics.Clear(Color.DarkGray);
            }
        }

        // Draw player car
        private void DrawCar(Graphics graphics)
        {
            Car car = _gameEngine.PlayerCar;

            if (_carImage != null)
            {
                graphics.DrawImage(_carImage, car.Bounds);  // Use image
            }
            else
            {
                // Fallback: blue rectangle
                using (var brush = new SolidBrush(Color.DeepSkyBlue))
                {
                    graphics.FillRectangle(brush, car.Bounds);
                }
            }
        }

        // Draw all obstacles
        private void DrawObstacles(Graphics graphics)
        {
            foreach (Obstacle o in _gameEngine.Obstacles)
            {
                if (_obstacleImage != null)
                {
                    graphics.DrawImage(_obstacleImage, o.Bounds);  // Use cone image
                }
                else
                {
                    // Fallback: red rectangle
                    using (var brush = new SolidBrush(Color.IndianRed))
                    {
                        graphics.FillRectangle(brush, o.Bounds);
                    }
                }
            }
        }

        // Update score display
        private void UpdateScoreLabel()
        {
            labelScore.Text = $"Score: {_gameEngine.Score}";
        }

        // Request graphics update
        private void InvalidateGameArea()
        {
            panelGameArea.Invalidate();
        }

        // Keyboard input handler
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_gameEngine == null || _gameEngine.IsGameOver)
                return;

            // Arrow key controls
            if (e.KeyCode == Keys.Left)
            {
                _gameEngine.MoveCarLeft();
                InvalidateGameArea();
            }
            else if (e.KeyCode == Keys.Right)
            {
                _gameEngine.MoveCarRight();
                InvalidateGameArea();
            }
        }

        // Score label click 
        private void labelScore_Click(object sender, EventArgs e)
        {
        }
    }
}