using CommunityToolkit.Mvvm.ComponentModel;

namespace StatelessBehaviorTree.Visualizer.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
}
