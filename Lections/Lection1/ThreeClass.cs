public class ThreeClass
{
    private int age;
    public int Age 
    {
        get { return age; }
        set
        {
            if (age < 18)
            {
                age = 18;
            }
            else
            {
                age = value;  // здесь value - это ключевое слово
            }
        }
    }


}