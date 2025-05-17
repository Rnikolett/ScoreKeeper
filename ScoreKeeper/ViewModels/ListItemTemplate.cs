using System;

namespace ScoreKeeper.ViewModels
{
    public class ListItemTemplate
    {
        public string Label { get; }
        public Type ModelType { get; }

        public ListItemTemplate(Type type)
        {
            ModelType = type;
            Label = type.Name.Replace("ViewModel", "");
        }
    }
}
