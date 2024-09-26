namespace DemoMVVMWithToolkit
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Detect orientation change based on screen size
        private void OnSizeChanged(object sender, EventArgs e)
        {
            if (Width > Height)
            {
                // Landscape mode: Place the image next to the text (2 columns, 1 row)
                MainGrid.RowDefinitions.Clear();
                MainGrid.ColumnDefinitions.Clear();

                MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                // Position the Image in the first column
                Grid.SetRow(PokemonImage, 0);
                Grid.SetColumn(PokemonImage, 0);

                // Position the text StackLayout in the second column
                Grid.SetRow(InfoStackLayout, 0);
                Grid.SetColumn(InfoStackLayout, 1);
            }
            else
            {
                // Portrait mode: Place the image above the text (1 column, 2 rows)
                MainGrid.RowDefinitions.Clear();
                MainGrid.ColumnDefinitions.Clear();

                MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                // Position the Image in the first row
                Grid.SetRow(PokemonImage, 0);
                Grid.SetColumn(PokemonImage, 0);

                // Position the text StackLayout in the second row
                Grid.SetRow(InfoStackLayout, 1);
                Grid.SetColumn(InfoStackLayout, 0);
            }
        }
    }
}