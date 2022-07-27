using Galaxy.API;
using System;

namespace Galaxy.Buttons
{
    internal class Staff
    {
        public static void Panel(QMTabMenu tabMenu)
        {
            var StaffPanel = new QMNestedButton(tabMenu, 4, 3, "Staff Panel", "Staff Panel", "Staff Panel");

            var StaffTest = new QMSingleButton(StaffPanel, 1, 0, "Test Button", delegate
            { Console.WriteLine("Thank You"); }, "Thanks Towxrd Love YA");
        }
    }
}
