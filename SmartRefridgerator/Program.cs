using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRefrigerator
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public abstract class Vegetable
    {
        public abstract string Name { get; }
    }
    public class Tomato : Vegetable
    {
        public override string Name => "Tomato";
    }
    public class Cabbage : Vegetable
    {
        public override string Name => "Cabbage";
    }

    public class LadyFinger : Vegetable
    {
        public override string Name => "Lady Finger";
    }
}
