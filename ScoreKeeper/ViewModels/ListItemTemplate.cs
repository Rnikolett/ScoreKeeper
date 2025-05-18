using System;

namespace ScoreKeeper.ViewModels
{
    // TODO delete this class/file, not used anymore
    [Obsolete("Old class")]
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
