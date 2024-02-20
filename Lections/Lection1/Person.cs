public abstract class Person : System.Object  // :System.Object - это родительский класс. В данном случае его можно не писать
{
    /*// открытые поля класса
    public string Name = string.Empty;  // имя
    public DateTime BirthDate;          // дата рождения
    public int Heitgh;                  // рост*/

    // только для чтения. При таком ограничении к полям, все экземпляры имеют только одно имя, которое задано, при создании класса
    public readonly string Name = string.Empty;  // имя
    public readonly DateTime BirthDate;          // дата рождения
    public readonly int Height;                  // рост

    public Person Father = null!;
    public Person Mother = null!;
    public Person[] Children = null!;

    // переопределение свойств
    protected abstract string HelloPhrase { get;}


    // создаем конструктор
    public Person(string name, DateTime birthDate, int height) 
    {
        this.Name = name;
        if (birthDate <= DateTime.Now)      // задаем дату с проверкой
        {
            this.BirthDate = birthDate; 
        }
        else 
        {
            Console.WriteLine($"{birthDate} не корректная дaта");
        }
                this.Height = height;
    }

    public Person(string name, DateTime birthDate)
    {
        this.Name = name;
        if (birthDate <= DateTime.Now)      // задаем дату с проверкой
        {
            this.BirthDate = birthDate;
        }
        else
        {
            Console.WriteLine($"{birthDate} не корректная дaта");
        }
    }

    public Person(string name)
    {
        this.Name = name;
    }


    public void Print() 
    {
        Console.WriteLine($"Имя - {Name}, Дата рождения - {BirthDate}, Рост - {Height}");
    }

    public bool IsAdult(int adultAge = 18)       // проверка на совершенноление с заданием порога совершеннолетия.
                                                 // С заданным параметром по-умлчанию
    {
        var delta = DateTime.Now.Year - BirthDate.Year;
        if (delta > adultAge || delta == adultAge && DateTime.Now.DayOfYear <= BirthDate.DayOfYear)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsAdult()       // проверка на совершенноление
    {
        return this.IsAdult(18);
    }


    public void AddFamilyInfo(Person father, Person mother, params Person[] children)  // инфо семьи, где params это когда массив
    {
        Father = father;
        Mother = mother;
        Children = children;
    }

    public void PrintFamily() 
    {
        if (Father != null)
        {
            Console.WriteLine("Отец: ");
            Father.Print();             // метод Print уже был создан
        }
        if (Mother != null)
        {
            Console.WriteLine("Мать: ");
            Mother.Print();
        }

        if (Children != null && Children.Length >0)
        {
            Console.WriteLine("Дети: ");
            foreach (var item in Children)
            {
                item.Print();
            }
        }
    }

    public bool GetChildren(out Person[] children)
    {
        if (Children != null && Children.Length != 0)
        {
            children = Children;
            return true;
        }
        else 
        {
            children = null!;
            return false;
        } 
    }


    // переопределение методов
    public virtual void SayHello()
    {
        Console.WriteLine("Привет Дмитрий Александрович");
    }


    // переопределение свойств
    public void SayHelloPhrase()
    {
        Console.WriteLine(this.HelloPhrase);
    }

    // статические методы
    public static bool AreSiblings(Person p1, Person p2)  // определим, являются ли экземпляры братьями или сестрами
    {
        if (p1.Mother == null || p2.Mother == null) return false;
        if (p1.Father == null || p2.Father == null) return false;

        if (p1.Mother.Equals(p2.Mother)) return false;
        if (p1.Father.Equals(p2.Father)) return false;
        return true;
    }



}