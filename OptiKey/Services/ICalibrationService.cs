using System.Threading.Tasks;
using System.Windows;

namespace OptiKey.Services
{
    public interface ICalibrationService
    {
        Task<string> Calibrate(Window parentWindow);
        bool CanBeCompletedWithoutManualIntervention { get; }
    }
}
