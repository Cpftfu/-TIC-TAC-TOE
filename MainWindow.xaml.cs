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

namespace WpfApp1
{
	public partial class MainWindow : Window
	{
		public string SHIT = "X";
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if ((sender as Button).Name == "_10")
			{
				End();
			}
			else
			{
				(sender as Button).Content = SHIT;
				(sender as Button).IsEnabled = false;
				if (Pobeda())
				{
					return;
				}
				Randomaizer();
			}

		}

		private void Randomaizer()
		{
			Button[] buttons = new Button[] { _1, _2, _3, _4, _5, _6, _7, _8, _9 };
			Random r = new Random();
			int jopa;
			do
			{
				jopa = r.Next(0, 9);
			} while (!(buttons[jopa].Content == "" || buttons[jopa].Content == null));
			if (SHIT == "X")
			{
				buttons[jopa].Content = "O";
			}
			else
			{
				buttons[jopa].Content = "X";
			}
			buttons[jopa].IsEnabled = false;
			if (Pobeda())
			{
				return;
			}
		}

		private bool Pobeda()
		{
			Button[] buttons = new Button[] { _1, _2, _3, _4, _5, _6, _7, _8, _9 };
			string[] lines = new string[]
			{
				_1.Content.ToString() + _2.Content.ToString() + _3.Content.ToString(),
				_1.Content.ToString() + _4.Content.ToString() + _7.Content.ToString(),
				_1.Content.ToString() + _5.Content.ToString() + _9.Content.ToString(),
				_2.Content.ToString() + _5.Content.ToString() + _8.Content.ToString(),
				_3.Content.ToString() + _5.Content.ToString() + _7.Content.ToString(),
				_3.Content.ToString() + _6.Content.ToString() + _9.Content.ToString(),
				_4.Content.ToString() + _5.Content.ToString() + _6.Content.ToString(),
				_7.Content.ToString() + _8.Content.ToString() + _9.Content.ToString()
							};

			foreach (var line in lines)
			{
				if (line == "XXX")
				{
					MessageBox.Show("ХУЙ ВЫЙГРАЛ");
					End();
					return true;
				}
				else if (line == "OOO") //ОООООООООООООООООООООО КТО ПРОЖИВАЕТ НА ДНЕ ОКЕАНА???
				{
					MessageBox.Show("НОЛИК ВЫЙГРАЛ");
					End();
					return true;
				}
			}
			if (!buttons.Any(b => b.Content == "" || b.Content == null))
			{
				MessageBox.Show("А НИКТО НЕ ВЫЙГРАЛ ХИХИ ХИХИ");
				End();
				return true;
			}
			return false;
		}

		private void End()
		{
			_1.Content = "";
			_1.IsEnabled = true;
			_2.Content = "";
			_2.IsEnabled = true;
			_3.Content = "";
			_3.IsEnabled = true;
			_4.Content = "";
			_4.IsEnabled = true;
			_5.Content = "";
			_5.IsEnabled = true;
			_6.Content = "";
			_6.IsEnabled = true;
			_7.Content = "";
			_7.IsEnabled = true;
			_8.Content = "";
			_8.IsEnabled = true;
			_9.Content = "";
			_9.IsEnabled = true;

			if (SHIT == "X")
			{
				SHIT = "O";
			}
			else
			{
				SHIT = "X";
			}

		}
	}
}
