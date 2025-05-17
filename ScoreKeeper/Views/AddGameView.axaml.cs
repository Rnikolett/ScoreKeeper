using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ScoreKeeper.Views;

public partial class AddGameView : UserControl
{
    public AddGameView()
    {
        InitializeComponent();
    }
    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        // TODO move to SingleGameView.axaml.cs

        //if (Game.DataContext is AddGameViewModel viewModel)
        //{
        //    var Players = viewModel.Rounds.First().RoundData.Keys;

        //    foreach (var player in Players)
        //    {
        //        Game.Columns.Add(new DataGridTextColumn()
        //        {
        //            Header = player,
        //            Binding = new Binding("RoundData[" + player + "]"),
        //            MaxWidth = 100
        //        });
        //    }
        //}
    }
}