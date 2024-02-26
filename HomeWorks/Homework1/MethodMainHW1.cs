namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork1
{
    internal class MethodMainHW1
    {
        public void Run()
        {
            var grantFatherFather = new FamilyMember() { Name = "Петр", BirthData = DateTime.Parse("10.06.1925"), Gender = Gender.Male, Father = null, Mother = null };
            var grantMotherFather = new FamilyMember() { Name = "Анастасия", BirthData = DateTime.Parse("23.06.1923"), Gender = Gender.Female, Father = null, Mother = null };
            grantFatherFather.Spouse = grantMotherFather;
            grantMotherFather.Spouse = grantFatherFather;


            var grantFatherMother = new FamilyMember() { Name = "Андрей", BirthData = DateTime.Parse("18.09.1924"), Gender = Gender.Male, Father = null, Mother = null };
            var grantMotherMother = new FamilyMember() { Name = "Мария", BirthData = DateTime.Parse("29.04.1925"), Gender = Gender.Female, Father = null, Mother = null };
            grantFatherMother.Spouse = grantMotherMother;
            grantMotherMother.Spouse = grantFatherMother;

            var father = new FamilyMember() { Name = "Михаил", BirthData = DateTime.Parse("17.09.1948"), Gender = Gender.Male, Father = grantFatherFather, Mother = grantMotherFather };
            var mother = new FamilyMember() { Name = "Наталья", BirthData = DateTime.Parse("28.02.1953"), Gender = Gender.Female, Father = grantFatherMother, Mother = grantMotherMother };
            father.Spouse = mother;
            mother.Spouse = father;

            var sonOneWifeFather = new FamilyMember() { Name = "Николай", BirthData = DateTime.Parse("16.10.1951"), Gender = Gender.Male, Father = null, Mother = null };
            var sonOneWifeMother = new FamilyMember() { Name = "Галина", BirthData = DateTime.Parse("13.03.1952"), Gender = Gender.Female, Father = null, Mother = null };
            sonOneWifeFather.Spouse = sonOneWifeMother;
            sonOneWifeMother.Spouse = sonOneWifeFather;


            var son = new FamilyMember() { Name = "Виктор", BirthData = DateTime.Parse("27.04.1971"), Gender = Gender.Male, Father = father, Mother = mother };
            var sonWife = new FamilyMember() { Name = "Светлана", BirthData = DateTime.Parse("15.11.1973"), Gender = Gender.Female, Father = sonOneWifeFather, Mother = sonOneWifeMother };
            son.Spouse = sonWife;
            sonWife.Spouse = son;

            var daughter = new FamilyMember() { Name = "Людмила", BirthData = DateTime.Parse("29.05.1974"), Gender = Gender.Female, Father = father, Mother = mother };

            var daughterSonOne = new FamilyMember() { Name = "Ольга", BirthData = DateTime.Parse("31.05.2000"), Gender = Gender.Female, Father = son, Mother = sonWife };
            var sonSonOne = new FamilyMember() { Name = "Игорь", BirthData = DateTime.Parse("12.12.2011"), Gender = Gender.Male, Father = son, Mother = sonWife };

            var family = new FamilyMemberService();
            var temp = family.AddPerson(grantFatherFather, grantMotherFather, grantFatherMother, grantMotherMother, father, mother,
                                son, daughter, daughterSonOne, sonSonOne);


            family.ViewParents(son);

            Console.WriteLine();
            son.ViewSpouse();

            Console.WriteLine();
            family.SpouseParents(son);

            Console.WriteLine();
            sonWife.ViewSpouse();

            family.SpouseParents(sonWife);


        }
    }
}
