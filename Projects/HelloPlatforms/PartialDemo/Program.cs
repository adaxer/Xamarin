using System;

namespace PartialDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public partial class ViewModel
    {
        public ViewModel()
        {
            OnConstructed();
            OnConstructedEvent?.Invoke();
        }

        partial void OnConstructed();

        public event Action OnConstructedEvent;
    }

    public partial class ViewModel
    {
        //partial void OnConstructed()
        //{

        //}
    }
}
