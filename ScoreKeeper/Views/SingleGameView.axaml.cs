using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ScoreKeeper.Views;

public partial class SingleGameView : UserControl
{
    public SingleGameView()
    {
        InitializeComponent();
    }

    // TODO move to SingleGameView.axaml.cs

    // TODO create DataGrid with dynamic columns in code-behind (SingleGameView.axaml.cs)
    // Diable sorting -> round number should always determine row order!

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