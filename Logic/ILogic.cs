using System.Threading.Tasks;

namespace Logic
{
    public interface ILogic
    {
         Task<string> MethodA();
         Task<string> MethodB();
    }
}
