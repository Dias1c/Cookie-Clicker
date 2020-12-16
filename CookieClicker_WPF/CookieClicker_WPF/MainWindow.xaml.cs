using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CookieClicker_WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      string text = $"Колво кликов в 1 клике: {CookieClicker.SkillClickSize}.\nСтоимость {CookieClicker.UpdatePrice}c";
      Tb_Redouble.Text = text;
      text = $"Шанс получить несколько пиченек при клике: +{CookieClicker.PrizeCookieSize}.\nСтоимость {CookieClicker.UpdatePrice}c";
      Tb_lucky.Text = text;
      text = $"Шанс: {CookieClicker.SkillLuckyChanse}\nСтоимость {CookieClicker.UpdatePrice}c";
      Tb_luckyUpdateChanse.Text = text;
      text = $"Приз: {CookieClicker.PrizeCookieSize}\nСтоимость {CookieClicker.UpdatePrice}c";
      Tb_luckyUpdatePrize.Text = text;
      text = $"Испытай удачу выйграй 1000 печенек.\nСтоимость {CookieClicker.UpdatePrice}c";
      Tb_PlayLotery.Text = text;
      text = $"Подкуп Улучшение шанса выйграша в лотореи на: 1%\nТекущий шанс: {CookieClicker.LoteryChanse}%\nСтоимость {CookieClicker.UpdatePrice}c";
      Tb_UpdateLoteryChanse.Text = text;
    }

    private void RefreshCookieCount()
    {
      Tb_CntCookie.Text = $"Кол-во Печенек: {CookieClicker.CountCookie}";
    }
    private void Btn_Cookie_Click(object sender, RoutedEventArgs e)
    {
      CookieClicker.MainCookie();
      RefreshCookieCount();
    }
    private void Btn_Redouble_Click(object sender, RoutedEventArgs e)
    {
      
      CookieClicker.UpdateSkillClickSize((Button)sender);

      string text = $"Колво кликов в 1 клике: {CookieClicker.SkillClickSize}.\nСтоимость {CookieClicker.UpdatePrice}c";
      Tb_Redouble.Text = text;
      RefreshCookieCount();
    }
    private void Btn_lucky_Click(object sender, RoutedEventArgs e)
    {
      Sp_Lucky.Visibility = Visibility.Visible;
      CookieClicker.UpdateSkillLucky((Button)sender);

      string text = $"Шанс получить несколько пиченек при клике: +{CookieClicker.PrizeCookieSize}.\nСтоимость {CookieClicker.UpdatePrice}c";
      Tb_lucky.Text = text;
      RefreshCookieCount();
    }

    private void Btn_luckyUpdateChanse_Click(object sender, RoutedEventArgs e)
    {
      CookieClicker.UpdateSkillLuckyChanse((Button)sender);

      string text = $"Шанс: {CookieClicker.SkillLuckyChanse}\nСтоимость {CookieClicker.UpdatePrice}c";
      Tb_luckyUpdateChanse.Text = text;
      RefreshCookieCount();
    }
    private void Btn_luckyUpdatePrize_Click(object sender, RoutedEventArgs e)
    {
      CookieClicker.UpdatePrizeCookieSize((Button)sender);

      string text = $"Приз: {CookieClicker.PrizeCookieSize}\nСтоимость {CookieClicker.UpdatePrice}c";
      Tb_luckyUpdatePrize.Text = text;
      RefreshCookieCount();
    }

    private void Btn_PlayLotery_Click(object sender, RoutedEventArgs e)
    {
      CookieClicker.PlayLotery();
      
      string text = $"Испытай удачу выйграй 1000 печенек.\nСтоимость {CookieClicker.UpdatePrice}c";
      Tb_PlayLotery.Text = text;
      RefreshCookieCount();
    }


    private void Btn_UpdateLoteryChanse_Click(object sender, RoutedEventArgs e)
    {
      CookieClicker.UpdateLoteryChanse((Button)sender);

      string text = $"Подкуп Улучшение шанса выйграша в лотореи на: 1%\nТекущий шанс: {CookieClicker.LoteryChanse}%\nСтоимость {CookieClicker.UpdatePrice}c";
      Tb_UpdateLoteryChanse.Text = text;
      RefreshCookieCount();
    }


  }

  public static class CookieClicker
  {

    public static long CountCookie = 0;
    public static int SkillClickSize = 1;

    public static bool SkillLucky = false;
    public static int SkillLuckyChanse = 1;
    public static int PrizeCookieSize = 100;

    public static int LoteryChanse = 10;

    public static int UpdatePrice = 10;
    //public static 

    public static void MainCookie()
    {
      CountCookie += 1 * SkillClickSize;

      if (SkillLucky)
      {
        Random rnd = new Random();
        if (rnd.Next(1, 101) <= SkillLuckyChanse)
        {
          CountCookie += PrizeCookieSize;
          MessageBox.Show($"Поздравляю вы получили {PrizeCookieSize}", "Prize");
        }
      }

    }

    public static void UpdateSkillClickSize(Button btn)
    {
      if (UpdatePrice <= CountCookie && SkillClickSize < 2)
      {
        CountCookie -= UpdatePrice;
        SkillClickSize = SkillClickSize * 2;

        if (SkillClickSize == 2)
          btn.Content = "MAX";
      }
      else if (!(UpdatePrice <= CountCookie))
        MessageBox.Show($"Недостаточно средств! Необходимо {UpdatePrice}");
      else
        MessageBox.Show($"Достигнута до максимума!");

    }

    public static void UpdateSkillLucky(Button btn)
    {
      if (UpdatePrice <= CountCookie && !SkillLucky)
      {
        CountCookie -= UpdatePrice;
        SkillLucky = true;

        if (SkillLucky)
          btn.Content = "MAX";
      }
      else if (!(UpdatePrice <= CountCookie))
        MessageBox.Show($"Недостаточно средств! Необходимо {UpdatePrice}");
      else
        MessageBox.Show($"Достигнута до максимума!");
    }
    public static void UpdateSkillLuckyChanse(Button btn)
    {
      if (UpdatePrice <= CountCookie && SkillLuckyChanse < 20)
      {
        CountCookie -= UpdatePrice;
        SkillLuckyChanse += 1;

        if (SkillLuckyChanse == 20)
          btn.Content = "MAX";
      }
      else if (!(UpdatePrice <= CountCookie))
        MessageBox.Show($"Недостаточно средств! Необходимо {UpdatePrice}");
      else
        MessageBox.Show($"Достигнута до максимума!");

    }
    public static void UpdatePrizeCookieSize(Button btn)
    {
      if (UpdatePrice <= CountCookie && PrizeCookieSize < 200)
      {
        CountCookie -= UpdatePrice;
        PrizeCookieSize += 1;

        if (PrizeCookieSize == 200)
          btn.Content = "MAX";
      }
      else if (!(UpdatePrice <= CountCookie))
        MessageBox.Show($"Недостаточно средств! Необходимо {UpdatePrice}");
      else
        MessageBox.Show($"Достигнута до максимума!");
    }


    public static void PlayLotery()
    {
      if (UpdatePrice <= CountCookie)
      {
        CountCookie -= UpdatePrice;
        Random rnd = new Random();
        if (rnd.Next(1, 101) <= LoteryChanse)
        {
          CountCookie += 1000;
          MessageBox.Show($"Поздравляю! Вы выйграли {1000}");
        }
      }
      else if (!(UpdatePrice <= CountCookie))
        MessageBox.Show($"Недостаточно средств! Необходимо {UpdatePrice}");
    }
    public static void UpdateLoteryChanse(Button btn)
    {
      if (UpdatePrice <= CountCookie && LoteryChanse < 20)
      {
        CountCookie -= UpdatePrice;
        LoteryChanse += 1;

        if (LoteryChanse == 20)
          btn.Content = "MAX";
      }
      else if (!(UpdatePrice <= CountCookie))
        MessageBox.Show($"Недостаточно средств! Необходимо {UpdatePrice}");
      else
        MessageBox.Show($"Достигнута до максимума!");
    }


  }

}
