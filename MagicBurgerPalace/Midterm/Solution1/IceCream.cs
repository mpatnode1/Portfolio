class IceCream : MenuItem{

    public override void MenuDisplay(){
        Console.WriteLine("It looks like the ice cream machine is behind you. You won't need to get help from the kitchen for this one.");
    }

    public void MenuItemName(){
        Console.ReadLine();
        Console.WriteLine("New Quest: Make a " + ItemName);
    }
}