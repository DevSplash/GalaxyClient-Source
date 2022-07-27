using Galaxy.API;
using System;

namespace Galaxy.Buttons
{
    internal class Supporters
    {
        public static void Support(QMNestedButton Info)
        {
            var Supporters = new QMNestedButton(Info, 4, 3, "Galaxy Supporters", "A doller a day can help change a mans life", "Galaxy Supporters");

            var Towxrd_Button = new QMSingleButton(Supporters, 1, 0, "Towxrd is a Bitch", delegate 
            { Console.WriteLine("Thank You"); }, "Thanks Towxrd Love YA");

            var Sunny_Button = new QMSingleButton(Supporters, 2, 0, "Sunny", delegate
            { Console.WriteLine("an old friend"); }, "An old Freind that i havent talked to in a while");

            var Evan_Button = new QMSingleButton(Supporters, 3, 0, "Even", delegate
            { Console.WriteLine("an old friend"); }, "An old Freind that i havent talked to in a while");

            var singleButton = new QMSingleButton(Supporters, 4, 0, "This Can Be You", delegate
            { Console.WriteLine("Thank You"); }, "Thank You");
        }
    }
}
