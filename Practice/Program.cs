using Autofac;

namespace Practice
{
    public interface IWork
    {
        void Working();
    }
    public class Student : IWork
    {
        public void Working()
        {
            Console.WriteLine("Student is learing...");
        }
    }
    public class Teacher : IWork
    {
        public void Working()
        {
            Console.WriteLine("Teacher is teaching...");
        }
    }
    public class Classroom
    {
        private IWork _work;
        public Classroom(IWork work)
        {
            this._work = work;
        }
        public void Working()
        {
            _work.Working();
        }
    }
    
    public class Program
    {
        private static IContainer Container { get; set; }   
        public static void Main(string[] args)
        {
           var builder =new ContainerBuilder();

            builder.RegisterType<Student>().As<IWork>();
            Container= builder.Build();

            Working();

        }
        public static void Working()
        {
            using (var scope=Container.BeginLifetimeScope())
            {
                var work = scope.Resolve<IWork>();
                work.Working();
            }
        }
    }
}