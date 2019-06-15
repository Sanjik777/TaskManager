using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
	public class FirstMenu
	{
		//----------- for Windows 10 ----------

	    public int Id { get; set; }                 //Id
		public string ApplicationName { get; set; } //Приложение
		public string State { get; set; }           //Состояние
		public double CPU { get; set; }             //ЦП %
		public double RAM { get; set; }             //Память
		public double DiskSpeed { get; set; }       //Диск
		public double NetSpeed { get; set; }        //Сеть
		public double GPU { get; set; }             //GPU
		public string Kernel3D { get; set; }        //ядро графического процессора

		//----------- for Windows 7 --------------

		//public string ApplicationName { get; set; }
		//public int CPU { get; set; }
		//public int RAM { get; set; }
		//public string Description { get; set; }
		//public string Bystrodeistvie { get; set; }
		//public string Network { get; set; }
		//public string Users { get; set; }
	}
}
