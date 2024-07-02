using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimeCafe
{
    public partial class FinalBasket : Window
    {
        double sumAllProducts;
        string textOnPromo = "_";
        double forSum;
        double saleFor;
        int bonusAll;
        public FinalBasket()
        {
            InitializeComponent();
        }
        public FinalBasket(double sumAllPRod)
        {
            InitializeComponent();
            sumAllProducts = sumAllPRod;
            sumAll.Text = sumAllProducts.ToString();
            foreach (RegistrClassAccount a in AllLists.accounts)
            {
                if (AllLists.idUser == AllLists.accounts.IndexOf(a))
                {
                    bonus.Text = Convert.ToString(a.BonusBall);
                }
            }
        }
        private void Bonus()
        {
            if (AllLists.clickButtonBonus == false)
            {
                foreach (RegistrClassAccount a in AllLists.accounts)
                {
                    if (AllLists.idUser == AllLists.accounts.IndexOf(a))
                    {
                        a.BonusBall = a.BonusBall + Convert.ToInt32(bonusAll);
                        saleFor = saleFor - bonusAll;
                        sale.Text = saleFor.ToString();
                        bonus.Text = a.BonusBall.ToString();
                        sumAllProducts = sumAllProducts + bonusAll;
                        sumAllProducts = sumAllProducts + forSum;
                        saleFor = saleFor - forSum;
                        break;
                    }
                }
                AllLists.clickButtonBonus = true;
            }
            sumAll.Text = sumAllProducts.ToString();
            if(AllLists.clickButtonPromo == false)
            {
                textOnPromo = promo.Text;
                foreach (PromokodsAddClass a in AllLists.promos)
                {
                    if (textOnPromo == a.NamePromo)
                    {
                        forSum = Convert.ToDouble((a.SalePromo / 100) * sumAllProducts);
                        if (sumAllProducts > forSum && sumAllProducts - forSum > 1)
                        {
                            sumAllProducts = sumAllProducts - forSum;
                            a.workPromo = false;
                            saleFor = saleFor + forSum;
                            mas.Text = "";
                            sale.Text = saleFor.ToString();
                            sumAll.Text = sumAllProducts.ToString();
                            break;
                        }
                        else
                        {
                            forSum = 0;
                            break;
                        }
                    }

                }
            }
        }
        public void BackBonus(object sender, RoutedEventArgs e)
        {
            Bonus();
        }
        public void NullAllBonus(object sender, RoutedEventArgs e)
        {
            if (AllLists.clickButtonBonus == true)
            {
                AllLists.clickButtonBonus = false;
                bonusAll = Convert.ToInt32(bonus.Text);
                sumAllProducts = sumAllProducts - bonusAll;

                if (sumAllProducts >= 1)
                {
                    saleFor = saleFor + bonusAll;
                    sumAll.Text = sumAllProducts.ToString();
                    foreach (RegistrClassAccount a in AllLists.accounts)
                    {
                        if (AllLists.idUser == AllLists.accounts.IndexOf(a))
                        {
                            a.BonusBall = a.BonusBall - bonusAll;
                            bonus.Text = Convert.ToString(a.BonusBall);
                            break;
                        }
                    }
                }
                else
                {
                    sumAllProducts = sumAllProducts + bonusAll;
                    bonusAll = Convert.ToInt32(sumAllProducts) - 1;
                    if (Convert.ToInt32(bonus.Text) >= bonusAll)
                    {
                        sumAllProducts = sumAllProducts - bonusAll;
                        sumAll.Text = sumAllProducts.ToString();
                        foreach (RegistrClassAccount a in AllLists.accounts)
                        {
                            if (AllLists.idUser == AllLists.accounts.IndexOf(a))
                            {
                                a.BonusBall = a.BonusBall - Convert.ToInt32(bonusAll);
                                bonus.Text = Convert.ToString(a.BonusBall);
                                break;
                            }
                        }
                        saleFor = saleFor + bonusAll;

                    }
                }
                sale.Text = saleFor.ToString();
            }
        }
        public void OpenText(object sender, RoutedEventArgs e)
        {
            if (AllLists.clickButtonPromo == true)
            {
                saleFor = Convert.ToInt32(sale.Text);
                AllLists.clickButtonPromo = false;
                promo.Text = AllLists.textToCopy;
                textOnPromo = promo.Text;
                foreach (PromokodsAddClass a in AllLists.promos)
                {
                    if (textOnPromo == a.NamePromo && a.workPromo == true)
                    {
                        forSum = Convert.ToDouble((a.SalePromo / 100) * sumAllProducts);
                        if (sumAllProducts > forSum && sumAllProducts - forSum > 1)
                        {
                            sumAllProducts = sumAllProducts - forSum;
                            a.workPromo = false;
                            saleFor = saleFor + forSum;
                            mas.Text = "";
                            sale.Text = saleFor.ToString();
                            sumAll.Text = sumAllProducts.ToString();
                            break;
                        }
                        else
                        {
                            forSum = 0;
                            AllLists.clickButtonPromo = true;
                            break;
                        }
                    }

                }

            }
            else
            {
                mas.Text = "Вы не отменили действие промокода!";
            }

        }
        public void ClosePromo(object sender, RoutedEventArgs e)
        {
            AllLists.clickButtonPromo = true;
            if (!string.IsNullOrEmpty(promo.Text))
            {
                textOnPromo = promo.Text;
                foreach (PromokodsAddClass a in AllLists.promos)
                {
                    if (textOnPromo == a.NamePromo)
                    {
                        a.workPromo = true;
                        saleFor = Convert.ToDouble(sale.Text);
                        saleFor = saleFor - Convert.ToDouble(forSum);
                        sale.Text = Convert.ToString(saleFor);
                        sumAllProducts = sumAllProducts + Convert.ToDouble(forSum);
                        forSum = 0;
                    }
                }
                sumAll.Text = sumAllProducts.ToString();
            }
            promo.Text = null;
            
        }
        public void Sale_Click(object sender, RoutedEventArgs e)
        {
            CloseWindowPromo();
            AllLists.clickButtonPromo = true;
            Bonus();
            new Sale().Show();
            Close();
        }
        public void Main_Click(object sender, RoutedEventArgs e)
        {
            CloseWindowPromo();
            AllLists.clickButtonPromo = true;
            Bonus();
            new MainWindow().Show();
            Close();
        }
        public void Blog_Click(object sender, RoutedEventArgs e)
        {
            CloseWindowPromo();
            AllLists.clickButtonPromo = true;
            Bonus();
            new Blog().Show();
            Close();
        }
        public void Cafes(object sender, RoutedEventArgs e)
        {
            CloseWindowPromo();
            AllLists.clickButtonPromo = true;
            Bonus();
            new Cafe().Show();
            Close();
        }
        public void Shop_Click(object sender, RoutedEventArgs e)
        {
            CloseWindowPromo();
            AllLists.clickButtonPromo = true;
            Bonus();
            new Shop().Show();
            Close();
        }
        public void Menu_Click(object sender, RoutedEventArgs e)
        {
            CloseWindowPromo();
            AllLists.clickButtonPromo = true;
            Bonus();
            new Menu().Show();
            Close();
        }
        public void CloseWindowPromo()
        {
            foreach (PromokodsAddClass a in AllLists.promos)
            {
                a.workPromo = true;
            }
        }
        public void Account(object sender, RoutedEventArgs e)
        {
            CloseWindowPromo();
            AllLists.clickButtonPromo = true;
            Bonus();
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
            CloseWindowPromo();
            AllLists.clickButtonPromo = true;
            Bonus();
            new Basket().Show();
            Close();
        }
    }
}
