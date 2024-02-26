
namespace ApplicationDevelopmentInCS.Lections.Lection2
{
    internal class ManLec2 : PersonLec2
    {
        public ManLec2(string name) : base(name) { }

        public ManLec2(string name, DateTime birthDate) : base(name, birthDate) { }

        protected override void TakeCareImplementation()
        {
                Console.WriteLine("Проверяет уроки, потом идет с детьми на прогулку");
        }
    }
}