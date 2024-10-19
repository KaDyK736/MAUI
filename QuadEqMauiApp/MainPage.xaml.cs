namespace QuadEqMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            DecimalPlacesStepper.ValueChanged += OnDecimalPlacesChanged;
        }

        private void OnDecimalPlacesChanged(object sender, ValueChangedEventArgs e)
        {
            DecimalPlacesLabel.Text = $"Знаков после запятой: {e.NewValue}";
        }

        protected void Solve(object sender, EventArgs e)
        {
            float a, b, c;
            if (float.TryParse(A.Text, out a) && float.TryParse(B.Text, out b) && float.TryParse(C.Text, out c))
            {
                if (a == 0)
                {
                    DisplayAlert("Ошибка", "Коэффициент A не может быть равен нулю!", "OK");
                    return;
                }

                QuadEquation eq = new QuadEquation(a, b, c);
                var x = eq.Solve();
                int decimalPlaces = (int)DecimalPlacesStepper.Value;
                string format = $"F{decimalPlaces}";

                if (x.Count == 0)
                {
                    X1.Text = "Нет корней!";
                    X2.Text = "";
                }
                else if (x.Count == 1)
                {
                    X1.Text = $"X1 = {x[0].ToString(format)}";
                    X2.Text = "";
                }
                else
                {
                    X1.Text = $"X1 = {x[0].ToString(format)}";
                    X2.Text = $"X2 = {x[1].ToString(format)}";
                }

                // Отображение дискриминанта в зависимости от состояния Switch
                if (ShowDiscriminantSwitch.IsToggled)
                {
                    DiscriminantLabel.Text = $"Дискриминант = {eq.D.ToString(format)}";
                    DiscriminantLabel.IsVisible = true;
                }
                else
                {
                    DiscriminantLabel.IsVisible = false;
                }
            }
            else
            {
                DisplayAlert("Ошибка", "Неправильный формат чисел!", "OK");
            }
        }
    }
}
