namespace ApplicationDevelopmentInCS
{
    internal class A
    {
        public void MethodA()
        {
            Console.WriteLine("Метод класса А");
        }

        

        public void MethA() 
        {
            MyDeleg myDelee = MethodA;
        } 
    }
}
