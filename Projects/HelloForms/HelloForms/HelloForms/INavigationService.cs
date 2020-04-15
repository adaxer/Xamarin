using System.Threading.Tasks;

namespace HelloForms
{
    public interface INavigationService
    {
        Task Navigate(string destination); 
    }
}