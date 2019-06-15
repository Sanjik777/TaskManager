using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TaskManager.Models;

namespace TaskManager
{
	/*
	 * Создать с помощью WPF диспетчер задач, в котором выводится информация по процессам.
	 * Придусмотреть кнопку снятие задачи.
	 * При возникновении ошибки во время остановки процесса, уведомить пользователя, но не завершать работу.
	 */
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			GetAllProcesses();
		}
		private void GetAllProcesses()
		{
			Process[] processes = Process.GetProcesses();
			List<FirstMenu> menu = new List<FirstMenu>();
			processTask.CanUserReorderColumns = false;

			foreach (var process in processes)
			{
				PerformanceCounter performanceCPU = new PerformanceCounter();
				performanceCPU.CategoryName = "Process";
				performanceCPU.CounterName = "% Processor Time";
				performanceCPU.InstanceName = process.ProcessName;

				PerformanceCounter performanceDisk = new PerformanceCounter();
				performanceDisk.CategoryName = "PhysicalDisk";
				//performanceDisk.CounterName = "% Disk Time";
				//performanceDisk.CounterName = "Disk Reads/sec";
				performanceDisk.CounterName = "Disk Writes/sec";
				performanceDisk.InstanceName = process.ProcessName;
				FirstMenu oneMenu = new FirstMenu();
				//oneMenu.ApplicationName = process.MainWindowTitle;
				oneMenu.Id = process.Id;
				oneMenu.ApplicationName = process.ProcessName;
				oneMenu.State = process.Responding.ToString();
				//Task task = new Task(() =>
				//{
				//	oneMenu.CPU = Math.Round(performanceCPU.NextValue(), 2);
				//});
				//oneMenu.CPU = Math.Round(performanceCPU.NextValue(), 2);
				oneMenu.RAM = process.WorkingSet64 / (1024 * 1024);
				//oneMenu.DiskSpeed = performanceDisk.NextValue();
				//oneMenu.NetSpeed =;
				//oneMenu.GPU =;
				//oneMenu.Kernel3D =;
				menu.Add(oneMenu);
			}
			processTask.ItemsSource = menu;
		}
		private void ButtonClick(object sender, RoutedEventArgs e)
		{
			if (processTask.SelectedItem == null)
			{
				MessageBox.Show($"Choose process");
			}
			else
			{
				try
				{
					FirstMenu menu = (FirstMenu)processTask.SelectedItem;
					List<Process> processes = Process.GetProcesses().ToList<Process>();
					foreach (var process in processes)
					{
						if (process.ProcessName == menu.ApplicationName && process.Id == menu.Id)
						{
							//process.Kill();
							MessageBox.Show($"Процесс с именем: {menu.ApplicationName} с индексом {menu.Id} удалён");
						}
					}
					GetAllProcesses();
				}
				catch (Exception exception)
				{
					MessageBox.Show($"Error: {exception}");
				}
			}
		}

		//Menu Exit
		private void MenuItemClick(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
