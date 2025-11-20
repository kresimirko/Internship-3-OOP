namespace Internship_3_OOP.Static.Menus;

public interface IMenu<TWorksWith>
{
    public static abstract void Show(TWorksWith worksWith);
}
