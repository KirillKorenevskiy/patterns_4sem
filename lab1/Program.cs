using System;

public interface I1
{
    int Property { get; set; }

    void Method();

    event EventHandler Event;

    int this[int index] { get; set; }
}

public class C1
{
    private const int PrivateConstant = 10;
    public const int PublicConstant = 20;
    protected const int ProtectedConstant = 30;

    private int privateField;
    public int publicField;
    protected int protectedField;

    private int PrivateProperty { get; set; }
    public int PublicProperty { get; set; }
    protected int ProtectedProperty { get; set; }

    public C1()
    {
        // Конструктор по умолчанию
    }

    public C1(C1 c1)
    {
        // Конструктор копирования
        privateField = c1.privateField;
        publicField = c1.publicField;
        protectedField = c1.protectedField;
        PrivateProperty = c1.PrivateProperty;
        PublicProperty = c1.PublicProperty;
        ProtectedProperty = c1.ProtectedProperty;
    }

    public C1(int privateValue, int publicValue, int protectedValue)
    {
        // Конструктор с параметрами
        privateField = privateValue;
        publicField = publicValue;
        protectedField = protectedValue;
    }

    private void PrivateMethod()
    {
        Console.WriteLine("Private метод");
    }

    public void PublicMethod()
    {
        Console.WriteLine("Public метод");
    }

    protected void ProtectedMethod()
    {
        Console.WriteLine("Protected метод");
    }

    public void ProtectedAndPrivte()
    {
        PrivateMethod();
        ProtectedMethod();
    }
}

public class C2 : I1
{

    private const int PrivateConstant = 50;
    public const int PublicConstant = 60;
    protected const int ProtectedConstant = 70;

    private int privateField;
    public int publicField;
    protected int protectedField;

    private int PrivateProperty { get; set; }
    public int PublicProperty { get; set; }
    protected int ProtectedProperty { get; set; }

    public C2()
    {
    }

    public C2(C2 c2)
    {
        privateField = c2.privateField;
        publicField = c2.publicField;
        protectedField = c2.protectedField;
        PrivateProperty = c2.PrivateProperty;
        PublicProperty = c2.PublicProperty;
        ProtectedProperty = c2.ProtectedProperty;
    }

    public C2(int privateValue, int publicValue, int protectedValue)
    {
        privateField = privateValue;
        publicField = publicValue;
        protectedField = protectedValue;
    }

    private void PrivateMethod()
    {
        Console.WriteLine("Private метод в C2");
    }

    public void PublicMethod()
    {
        Console.WriteLine("Public метод в C2");
    }

    protected void ProtectedMethod()
    {
        Console.WriteLine("Protected метод в C2");
    }

    public int Property { get; set; }

    public void Method()
    {
        Console.WriteLine("метод в C2 из интерфейса");
    }

    public event EventHandler Event;

    public void onEvent()
    {
        Event?.Invoke(this, EventArgs.Empty);
    }

    public int this[int index]
    {
        get { return index * 2; }
        set { Console.WriteLine($"установка {value} в индекс: {index}"); }
    }
}


public class C3: I1
{
    private int privateField;
    protected int protectedField;
    public int publicField;

    public int Property { get; set; }

    public event EventHandler Event;
    public void onEventt()
    {
        Event?.Invoke(this, EventArgs.Empty);
    }

    public C3() { }

    public int this[int index]
    {
        get { return index * 2; }
        set { Console.WriteLine($"установка {value} в индекс: {index}"); }
    }

    public void Method()
    {
        Console.WriteLine("Метод в C3");
    }
}

public class C4 : C3
{
    public C4()
    {
        protectedField = 100;
        publicField = 200;
        Property = 300;
        Method();
        this[2] = 400;
    }

    protected new void ProtectedMethod()
    {
        Console.WriteLine("Protected метод в C4");
    }

    public void NewMethod()
    {
        Console.WriteLine("Новый метод в C4");
    }
}



public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("------------------Задание 1");
        C1 obj1 = new C1();
        C1 obj4 = new C1(55, 105, 155);
        C1 obj2 = new C1(obj4); 
        C1 obj3 = new C1(5, 10, 15); 

        obj1.publicField = 100; 
        int fieldValue = obj1.publicField; 
        Console.WriteLine(fieldValue);

        Console.WriteLine(obj2.publicField);

        obj1.PublicProperty = 200; 
        int propertyValue = obj1.PublicProperty; 

        Console.WriteLine(obj3.publicField);

        obj1.PublicMethod();
        obj1.ProtectedAndPrivte();


        Console.WriteLine("------------------Задание 3");

        C2 obj = new C2();

        Console.WriteLine(C2.PublicConstant); 

        obj.publicField = 100;
        Console.WriteLine(obj.publicField);

        obj.PublicProperty = 200;
        Console.WriteLine(obj.PublicProperty);

        obj.PublicMethod();
        obj.Method();

        obj.Property = 1000;
        Console.WriteLine(obj.Property);

        obj[2] = 50; 
        Console.WriteLine(obj[2]);

        obj.Event += (sender, e) => Console.WriteLine("событие сработало в 3 задании");
        obj.onEvent();

        Console.WriteLine("------------------Задание 4");

        C4 objj = new C4();

        objj.publicField = 500;
        Console.WriteLine(objj.publicField); 

        objj.Property = 600;
        Console.WriteLine(objj.Property);

        objj.Method();

        objj[2] = 700; 
        Console.WriteLine(objj[2]);

        objj.Event += (sender, e) => Console.WriteLine("событие в 4 задании сработало");

        objj.onEventt();

        objj.NewMethod(); 

    }
}