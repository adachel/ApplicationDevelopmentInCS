namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork1
{
    internal class FamilyMemberService
    {
        public List<FamilyMember>? Family { get; set; }

        public List<FamilyMember> AddPerson(params FamilyMember[] person)
        {
            var family = new List<FamilyMember>();
            family.AddRange(person);
            return family;
        }

        public void ViewParents(FamilyMember person)  // родители
        {
            Console.WriteLine("Отец: " + person.Father);
            Console.WriteLine("Мать: " + person.Mother);
        }

        public void ViewGrandFather(FamilyMember person) // дедушки
        {
            Console.WriteLine($"Отцовская ветка: {person.Father?.Father}");
            Console.WriteLine($"Материнская ветка: {person.Mother?.Father}");
        }

        public void ViewGrandMother(FamilyMember person) // бабушки
        {
            Console.WriteLine($"Отцовская ветка: {person.Father?.Mother}");
            Console.WriteLine($"Материнская ветка: {person.Mother?.Mother}");
        }

        public void GrandOldFather(FamilyMember person) // самый старший дед
        {
            while (person.Father != null)
            {
                person = person.Father;
            }
            Console.WriteLine(person);
        }

        public void Oldest(List<FamilyMember> family) // самый старший вообще
        {
            var temp = new DateTime();
            temp = DateTime.MaxValue.ToLocalTime();
            foreach (var person in family)
            {
                if (temp > person.BirthData)
                {
                    temp = person.BirthData;
                }
            }

            foreach (var person in family)
            {
                if (person.BirthData == temp)
                {
                    Console.WriteLine("Самый старший: " + person);
                }
            }
        }

        public void SpouseParents(FamilyMember person)
        {
            Console.WriteLine($"Имя супруга(и) - {person.Spouse?.Name}. Отец: " + person.Spouse?.Father);
            Console.WriteLine($"Имя супруга(и) - {person.Spouse?.Name}. Мать: " + person.Spouse?.Mother);
        }
    }
}
