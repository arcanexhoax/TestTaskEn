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

namespace TestTask {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();

			DataContext = new ApplicationView();
		}

		private void daySelectionChanged(object sender, SelectionChangedEventArgs e) {
			GetWeather();
		}

		private void citySelectionChanged(object sender, SelectionChangedEventArgs e) {
			GetWeather();
		}

		private void GetWeather() {
			if (citySelected.SelectedItem != null && daySelected.SelectedIndex != -1) {
				Weather weather = new Weather(citySelected.SelectedItem.ToString(), (Days)daySelected.SelectedIndex);
				mainLabel.Content = weather.Main;
				temperatureLabel.Content = weather.Temperature.ToString();
				humidityLabel.Content = weather.Humidity.ToString();
				pressureLabel.Content = weather.Pressure.ToString();
				windLabel.Content = weather.WindSpeed.ToString();
			}
		}
	}
}
