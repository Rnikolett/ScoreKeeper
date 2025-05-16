using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ScoreKeeper.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    
    [ObservableProperty]
    private bool _isPaneOpen = true;

    [ObservableProperty]
    private int _isVisible = 1;

    [ObservableProperty]
    private ViewModelBase _currentPage = new HomePageViewModel();

    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
        if (IsVisible == 1) IsVisible = 0; else IsVisible = 1;
    }
    [ObservableProperty]
    private ListItemTemplate _selectedListItem;

    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value is null) return;
        var instance = Activator.CreateInstance(value.ModelType);
        if (instance is null) return;
        CurrentPage = (ViewModelBase)instance;
    }
    public ObservableCollection<ListItemTemplate> Items { get; } = new()
    {
        new ListItemTemplate(typeof(HomePageViewModel)),
        new ListItemTemplate(typeof(AddGameViewModel))
    };

    


    
}

