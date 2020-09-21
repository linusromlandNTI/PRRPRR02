using System;
namespace OOPTest
{
    public class Person
    {
        string name;
        int age;
        bool alive;
        string bloodtype;
        string healthcondition;
        DateTime lastEaten;
        bool hungry = false;

        public string Name
        {
            get { return name; }
        }
        public Person(string nameIn, int ageIn, bool aliveIn, string bloodtypeIn, string healthconditionIn)
        {
            lastEaten = DateTime.Now;
            name = nameIn;
            age = ageIn;
            alive = aliveIn;
            bloodtype = bloodtypeIn;
            healthcondition = healthconditionIn;
        }
        public bool IsHungry()
        { //checks if the time was to long ago and the person then is hungry. 
            DateTime dateNow = DateTime.Now;
            if (alive)
            {
                hungry = true;
            }
            return hungry;
        }
        public void Eat()
        { //sets the last time eaten to current time, aka not hungry.
            if (alive)
            {
               lastEaten = DateTime.Now;
            }
        }
        public void Kill()
        {
            if (alive)
            {
                alive = false;
            }
        }
        public void Revive()
        {
            if (!alive)
            {
                alive = true;
            }
        }
        public void PrintInformation()
        {
            Console.WriteLine("Name: {1}\nAge: {2}\nalive: {3}\nBloodtype: {4}\nHealtCondition: {5}", name, age, alive, bloodtype, healthcondition);
        }
    }
}
