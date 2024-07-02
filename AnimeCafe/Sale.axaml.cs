using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace AnimeCafe;

public partial class Sale : Window
{
    List<RegistrClassAccount> SborAccount = new List<RegistrClassAccount>();
    public Sale()
    {
        InitializeComponent();
    }

    public void Main(object sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }

    public void Blog_Click(object sender, RoutedEventArgs e)
    {
        new Blog().Show();
        Close();
    }
    public void Cafe_Click(object sender, RoutedEventArgs e)
    {
        new Cafe().Show();
        Close();
    }
    public void Shop_Click(object sender, RoutedEventArgs e)
    {
        new Shop().Show();
        Close();
    }
    public void Menu_Click(object sender, RoutedEventArgs e)
    {
        new Shop().Show();
        Close();
    }
    public void SpecialMenu(object sender, RoutedEventArgs e)
    {
        new Shop().Show();
        Close();
    }
    public void Account(object sender, RoutedEventArgs e)
    {
        if (AllLists.accounts.Count > 0)
        {
            if (AllLists.idUser != null)
            {
                new PersonalAccount().Show();
                Close();
            }
            else if (AllLists.idAdmin == 1)
            {
                new Admin().Show();
                Close();
            }
            else
            {
                new LoginAccount().Show();
                Close();
            }
        }
        else if (AllLists.idAdmin == 1)
        {
            new Admin().Show();
            Close();
        }
        else
        {
            new Registration().Show();
            Close();
        }
    }
    public void BasketShop(object sender, RoutedEventArgs e)
    {
        new Basket().Show();
        Close();
    }
}