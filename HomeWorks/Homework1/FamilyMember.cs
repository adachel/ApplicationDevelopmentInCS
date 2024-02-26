namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork1
{
    internal class FamilyMember
    {
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        public FamilyMember? Father { get; set; }
        public FamilyMember? Mother { get; set; }
        public DateTime BirthData { get; set; }
        public FamilyMember? Spouse { get; set; }


        public override string? ToString()
        {
            return $"Имя - {Name}, Дата рождения - {BirthData}";
        }

        public void ViewSpouse()
        {
            string temp = "";
            if (Spouse?.Gender == Gender.Male)
            {
                temp = "Муж";
            }
            else temp = "Жена";

            Console.WriteLine($"Имя - {Name}. {temp} - {Spouse?.Name}");
        }
    }
}
