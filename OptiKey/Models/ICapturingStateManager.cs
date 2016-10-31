using System.ComponentModel;

namespace OptiKey.Models
{
    public interface ICapturingStateManager : INotifyPropertyChanged
    {
        bool CapturingMultiKeySelection { get; set; }
    }
}
