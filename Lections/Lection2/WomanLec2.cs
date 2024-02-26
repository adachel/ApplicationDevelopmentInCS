
namespace ApplicationDevelopmentInCS.Lections.Lection2
{
    internal class WomanLec2 : PersonLec2
    {
        public WomanLec2(string name, DateTime birthDate) : base(name, birthDate){ }

        protected override void TakeCareImplementation()
        {
              Console.WriteLine("Кормит ужином, затем укладывает спать");
        }
    }
}