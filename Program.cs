using System.Text.Json.Serialization;
using System.Net.Mail;
namespace TryLambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var fruit = new string[] { "apple", "Banana", "cherry", "mange", "pineapple" };
            var project = fruit.Select(x => x.Length);
            var firstChar = fruit.Select(x=>x[..2]);
            fruit[0].Split();
            firstChar.Print("testing");
            var result = arr.Where(s => s%2 ==1).Sum();
            Console.WriteLine(result);
            var chunkTest = arr.Chunk(3);
            var groups = arr.GroupBy(i => $"{(i % 3)}");
            foreach (var group in groups) {
                Console.WriteLine($"in group {group.Key}:");
                foreach (int i in group) { 
                    Console.Write(i);
                }
                Console.WriteLine("");
             }
            var sumPerGroup = arr.GroupBy(i => $"Group {(i % 3)}").Select(
                (group, idx) => $"{group.Key} has sum of {group.Sum()}");
            sumPerGroup.Print("Group Sum");
            
            //foreach (var chunk in chunkTest) { 
              //  Console.Write(chunk);
            //}
            //Console.WriteLine();
            //foreach (var i in result) {
              //  Console.WriteLine(i);
            //}
        
        }

        public static int Solution(int value)
        =>Enumerable.Range(0, value).Where((i => i % 3 == 0 || i % 5 == 0)).Sum();

        public static string UniqueInOrder<T>(IEnumerable<T> iterable)
        {

            return iterable.Where((item, index) => index == 0 || !item.Equals(iterable.ElementAt(index - 1))).ToString();
        }
    }

    static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> arr, string title) {
            Console.WriteLine($"---------{title}-------");
            foreach (var item in arr) { 
            Console.WriteLine($"{item}");
            }

        }

    }
    public class Person {

        //field
        private DateTime _dob;
        private string _firstName;
        private string _lastName;
        private string _email;
        private Coordinate _coordinate;
        //property
        //age would be a readonly property
        public int Age { get
            {
                return DateTime.Now.Year - _dob.Year;
            }
        }
        public string FirstName { get { return _firstName; } }
        public string LastName => _lastName;
        public string Email {
            get { return _email; }
            set { if (isValidEmail(value)) _email = value;
                else
                    throw new ArgumentException("Invalid email");
            }
        }
        private bool isValidEmail(string emailToCheck)
        {
            try
            {
                MailAddress m = new MailAddress(emailToCheck);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public string FullName => _firstName + " " + _lastName;
        //Properties offered to see person's current position on the x-y plane
        public string Position => $"I am at x:{_coordinate.X}, y:{_coordinate.Y}";
        public Coordinate CurrentCoordinate => _coordinate;
        public bool CanDrive => Age > 16;
        public bool CanDrink => Age > 21;




        //Construsctor Method
        public Person(string firstname, string lastname, DateTime dob, string email)
        {
            _firstName = firstname;
            _lastName = lastname;
            _dob = dob;
            this.Email = email;
        }

        //Instance Method

        public void Move(Direction whichWay, int stepsToTake)
        {
            switch (whichWay)
            {
                case Direction.Up:
                    _coordinate.Y += stepsToTake;
                    break;
                case Direction.Down:
                    _coordinate.Y -= stepsToTake;
                    break;
                case Direction.Left:
                    _coordinate.X -= stepsToTake;
                    break;
                case Direction.Right:
                    _coordinate.X += stepsToTake;
                    break;
                default:
                    break;
            }
        }


        public double DistanceTo(Person otherGuy)
        {
            int deltaX = (this.CurrentCoordinate.X - otherGuy.CurrentCoordinate.X);
            int deltaY = (this.CurrentCoordinate.Y - otherGuy.CurrentCoordinate.Y);
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }


    }


  

}