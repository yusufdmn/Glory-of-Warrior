using Health_System.Model;
using Health_System.View;

namespace Health_System.Controller
{
    public interface IHealthController
    {
        void Initialize(IHealthModel healthModel, IHealthView healthView);
    }
}