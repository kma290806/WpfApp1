using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CController controller;
        CPlayer player;
        DispatcherTimer timer;
        double gameTime=60;
        bool gameStarted = false;

        public MainWindow()
        {
            InitializeComponent();
            player = new CPlayer(1.0);//перезарядка 1
            controller = new CController(2.0, 0.0, GameCanvas.Width, GameCanvas.Height);
            //каждые 2 секунды объекты
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            GameCanvas.MouseDown += GameCanvas_MouseDown;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!gameStarted)
            {
                gameStarted = true;
                timer.Start();
                Start.Content = "Restart";
            }
            else
            {
                GameCanvas.Children.Clear();
                player = new CPlayer(1.0);
                controller = new CController(2.0, 0.0, GameCanvas.Width, GameCanvas.Height);
                gameTime = 60;
                Update();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //начало игры
            if (gameStarted)
            {
                controller.update(0.1);
                player.update(0.1);

                gameTime -= 0.1;
                //конец игры
                if (gameTime <= 0)
                {
                    gameTime = 0;
                    timer.Stop();
                    gameStarted = false;
                    MessageBox.Show($"Игра окончена! Ваш счет: {controller.getPoints()}");
                }

                DrawObjects();
                Update();
            }
        }

        private void GameCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(GameCanvas);
            string clickMessage = controller.mouseClick(mousePosition, player);

            if (!string.IsNullOrEmpty(clickMessage))
            {
                message.Items.Add($"{clickMessage}");

                // Прокручиваем к последнему сообщению
                if (message.Items.Count > 0)
                    message.ScrollIntoView(message.Items[message.Items.Count - 1]);
            }

            // Обновляем отображение очков
            ScoreText.Text = $"Очки: {controller.getPoints():F0}";
        }

        private void DrawObjects()
        {
            GameCanvas.Children.Clear();

            foreach (var obj in controller.getObjects())
            {
                Ellipse sprite = obj.getSprite();
                GameCanvas.Children.Add(sprite);
            }
        }

        private void Update()
        {
            ScoreText.Text = $"Очки: {controller.getPoints():F1}";
            TimerText.Text = $"Время: {gameTime:F1}";
        }
    }
}