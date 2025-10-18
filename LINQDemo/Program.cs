namespace LINQDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, DEPI_ALX3_SWD5_S2 !");
            //Linq 
            List<string> names = new List<string>();
            names.Add("Ahmed");
            names.Add("Ali");
            names.Add("tamer");
            //LINQ To Object 
            var result = names.Select(x => x.Contains("r")).ToList();


            //------------------------ LINQ--------------------------------
            // LINQ Principles:-
            //------------------
            //1)Implicit type(Var)
            //int Value 
            int? Number = null;
            int x = 5;
            var y = 10;
            //Console.WriteLine(y.length);
            //y = "ahmed"; Error
            var z = (string)null;
            var date = DateTime.Now;
            //Array 
            //ArrayList
            //List
            object ob = 123;
            int total = (int)ob + 100;
            dynamic d = 100;
            int TotalWithDymaic = d + 200;
            d = "Ahmed";
            string str = "New String ";
            Console.WriteLine(str.Length);
            //Error in Runtime
            dynamic dd = 120;
            //Console.WriteLine(dd.length);
            //---------------------------------------------------
            //2)Object Initializer.

            Employee Ahmed = new Employee() { Id = 1, Name = "Ahmed" };


            //3)Collection Initializer.
            //Type Can Be Datatype   Class , Enum , struc , Interface , Delegate 

            // List<Employee> Employees = new List<Employee>();
            //Collection Get elements index
            //Employees.Add(Ahmed);
            // Anonymous Object 
            List<Employee> Employees = new List<Employee>()
            {
                new Employee{ Id = 1 , Name = "Ahmed" ,age = 25 },
                new Employee{ Id = 2 , Name = "tammer" ,age = 24},
                new Employee{ Id = 3  , Name = "Ahmed" ,age = 30 },
                new Employee{ Id = 4 , Name = "yasser",age = 26 }
            };

            //4)Dynamic Name.
            //string str1 = "New String ";
            //Console.WriteLine(str1.Length);
            ////Error in Runtime
            //dynamic dd1 = 120;
            //Console.WriteLine(dd1.length);

            //5)Anonymous Types.
            var aa = new { Id = 1, Name = "sayed", age = 40, Job = "Developer" };
            var a = new { Id = 1, Name = "sayed", age = 40, Job = "Developer" };
            //a.Id = 2; Error Read Only
            //


            var result1 = from emp in Employees
                          where emp.age >= 25
                          select emp;

            foreach (var item in result1)
            {
                Console.WriteLine(item.ToString());
            }

            var result2 = from emp in Employees
                          where emp.age >= 25
                          select new { emp.Name, emp.age };



            foreach (var item in result2)
            {
                Console.WriteLine(item.Name + " " + item.age);
            }

            //6)Generic type.
            IntList Mylist = new IntList(5);
            Mylist.Add(100);
            Mylist.Add(200);
            Mylist.Add(300);
            Mylist.Add(400);
            Mylist.Add(500);

            for (int i = 0; i < Mylist.Length; i++)
            {
                Console.WriteLine(Mylist.GetValue(i));
            }


            GenericList<string> Namess = new GenericList<string>(3);   //Refec Class
            GenericList<double> Salaries = new GenericList<double>(3); //Value Struc


            //7)Extension Methods.
            StaticClass.SayHello();   //= new StaticClass();

            int Num = 5;
            Console.WriteLine(Num.Add(50));
            Console.WriteLine(Num);
            Console.WriteLine(MyInt.Add(100, 50));



            //9)Linq To Object(Linq Query). Collection
            var Result3 = Employees.Where(e => e.Name == "Ahmed");
            foreach (var item in Result3)
            {
                Console.WriteLine(item.ToString());
            }

            //8)Delegate.

            MyString Ms = new MyString(new Program().Test);
            Ms("Sayed Hawas");

            /*
                Delegate Type Like:-
                ---------------------
                -Func      : delegate Which return One Value.              16 Input parameters  With Return (Function) 17 Output
                             - Func<int,int> increment = i => i+1;

                -Action    : delegate which not return Value.             16 Input parameters Without Return (Void)  
                             - Action<int> d=x=>Console.WriteLine(x);

                -Predicate : delegate which return bool only.
                             - predicate<int> cc=c=>true;                 1 Input parameters With Return (True Or False)
             */
            Func<int, int, int> Add = delegate (int x, int y) { return x + y; };


            Console.WriteLine(Add(100, 200));


            //10)Anonymous Delegate.
            //11)Anonymous Method. 
            //12)Linq Lambda Expression.

            Func<int, int, int> Add2 = (Nu1, Nu2) => Nu1 + Nu2;

            Predicate<int> Check = delegate (int x) { return x > 5; };
            Predicate<int> Check2 = x => x > 5;

            var Result5 = Employees.Where(e => e.Id > 2);

            //13)build -in Delegate.
            /*
                Delegate Type Like:-
                ---------------------
                -Func      : delegate Which return One Value.              16 Input parameters  With Return (Function) 17 Output
                            - Func<int,int> increment = i => i+1;

                -Action    : delegate which not return Value.             16 Input parameters Without Return (Void)  
                            - Action<int> d=x=>Console.WriteLine(x);

                -Predicate : delegate which return bool only.
                            - predicate<int> cc=c=>true;                 1 Input parameters With Return (True Or False)
            */
            Console.ReadLine();

        }
        public int Sum(int x, int y)
        {
            return x + y;
        }
        public void Test(string name)
        {
            Console.WriteLine($"My Name is {name}");
        }
        public delegate void MyString(string str);
    }
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }


        public override string ToString()
        {
            // this.
            return $"Id {Id} Name : {Name} Age {age}";
        }
    }
    class IntList
    {
        private int[] MyList;
        private int CurrentIndex = 0;
        public int Length { get; }
        public IntList(int Index)
        {
            MyList = new int[Index];
            Length = Index;
        }
        public void Add(int value)
        {
            MyList[CurrentIndex] = value;
            CurrentIndex++;
        }
        public int GetValue(int Index)
        {
            return MyList[Index];
        }
    }
    public class GenericList<T>  //where T:struct    where T:class
    {
        private T[] MyList;
        private int CurrentIndex = 0;
        public int Length { get; }
        public T GetType { set; get; }
        public GenericList(int Index)
        {
            MyList = new T[Index];
            Length = Index;
        }
        public void Add(T value)
        {
            MyList[CurrentIndex] = value;
            CurrentIndex++;
        }
        public T GetValue(int Index)
        {
            return MyList[Index];
        }
    }
    public static class StaticClass
    {
        //this Error
        static StaticClass()
        {
            //this
            Console.WriteLine("Print From Static Class");
        }

        public static void SayHello()
        {
            Console.WriteLine("Hello ....");
        }
    }
    public static class MyInt
    {
        public static int Add(this int x, int y)
        {
            return x + y;
        }
    }
    //class Test : Int128
    //{ 

    //}

}
