public class SomeClass
{
    public SomeClass(int someproperty)
    {
        this.SomeProperty = someproperty;
    }

    // свойства класса
    public int SomeProperty { get; init; }  // get - можно прочитать, init - можно установить в момент инициализации класса
    public int SomeProperty1 { get; init; } = 20;  // здесь по-умолчанию 20
    public int SomeProperty2 { get; set;}  // set - можно менять




}