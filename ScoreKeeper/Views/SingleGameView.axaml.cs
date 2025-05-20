using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using ScoreKeeper.ViewModels;

namespace ScoreKeeper.Views;

public partial class SingleGameView : UserControl
{
    public SingleGameView()
    {
        InitializeComponent();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        if (Game.DataContext is SingleGameViewModel viewModel)
        {
            foreach (var player in viewModel.Game.PlayersList)
            {
                Game.Columns.Add(new DataGridTextColumn()
                {
                    Header = player,
                    Binding = new Binding("RoundData[" + player + "]"),
                    MaxWidth = 100,
                    MinWidth = 100,
                });
                Score.Columns.Add(new DataGridTextColumn()
                {
                    Header = player,
                    Binding = new Binding("RoundData[" + player + "]"),
                    MaxWidth = 100,
                });
            }
        }
    }
}