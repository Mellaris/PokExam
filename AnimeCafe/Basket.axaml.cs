using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimeCafe;

public partial class Basket : Window
{
    double sumAllProducts;
    int forSum = 0;
    int bonusAll;
    string textOnPromo = "_";
    double sale;
    int helpForSale = 0;

    public Basket()
    {
        InitializeComponent();
        if (AllLists.accounts.Count > 0)
        {
            BasketList.ItemsSource = AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket;
            foreach (ProductClassAdd product in AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket)
            {
                if (product.KolProdAfterClick > product.KolProduct)
                {
                    product.KolProdAfterClick = product.KolProduct;
                }
            }
        }

        SumProductsInBasket();
    }
    public void OpenNewBasket(object sender, RoutedEventArgs e)
    {
        new FinalBasket(sumAllProducts).Show();
        Close();
    }
    
    public void SumProductsInBasket()
    {
        sumAllProducts = 0;
        if (AllLists.accounts.Count > 0)
        {
            foreach (ProductClassAdd a in AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket)
            {
                sumAllProducts = sumAllProducts + (a.KolProdAfterClick * a.CostProduct);
            }
            SumAll.Text = sumAllProducts.ToString();
        }
    }
    public void DobMinus(object sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        foreach (ProductClassAdd product in AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket)
        {
            if (selectDel == product.DobPlusId)
            {
                if (product.KolProdAfterClick > 1)
                {
                    product.KolProdAfterClick--;
                }
            }
        }
        if (AllLists.accounts.Count > 0)
        {
            BasketList.ItemsSource = AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket.ToList();
        }
        SumProductsInBasket();
    }
    public void DobPlus(object sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        foreach (ProductClassAdd product in AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket)
        {
            if (selectDel == product.DobPlusId)
            {
                product.KolProdAfterClick++;
                if (product.KolProdAfterClick > product.KolProduct)
                {
                    product.KolProdAfterClick = product.KolProduct;
                }
            }
        }
        if (AllLists.accounts.Count > 0)
        {
            BasketList.ItemsSource = AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket.ToList();
        }
        SumProductsInBasket();
    }
    public void DeleteProductFromBasket(object sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        foreach (ProductClassAdd product in AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket)
        {
            if (selectDel == product.DeleteId)
            {
                AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket.RemoveAt(AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket.IndexOf(product));
                break;
            }
        }
        if (AllLists.accounts.Count > 0)
        {
            BasketList.ItemsSource = AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket.ToList();
        }
        InitializeComponent();
    }

    public void Sale_Click(object sender, RoutedEventArgs e)
    {
        new Sale().Show();
        Close();
    }
    public void Main_Click(object sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }
    public void Blog_Click(object sender, RoutedEventArgs e)
    {
        new Blog().Show();
        Close();
    }
    public void Cafes(object sender, RoutedEventArgs e)
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
        new Menu().Show();
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
}