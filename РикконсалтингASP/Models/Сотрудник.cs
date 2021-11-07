using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.Models
{
    public partial class Сотрудник
    {

		[Key]
		public int КодСотрудники { get; set; }


		public String НазвОрганиз { get; set; }


		public String Фамилия { get; set; }


		public String Имя { get; set; }	

	    public String Отчество { get; set; }


	public String ФИОСборное { get; set; }

	public String ФамилияРодПад	{ get; set; }


	public String ИмяРодПад { get; set; }

		public String ОтчествоРодПад { get; set; }


		public String ФИОРодПод { get; set; }


		public String ПаспортСерия { get; set; }


		public String ПаспортНомер { get; set; }


		public String ПаспортКогдаВыдан { get; set; }


		public String ДоКакогоДейств { get; set; }


		public String ПаспортКемВыдан { get; set; }


		public String ИДНомер { get; set; }


		public String Регистрация { get; set; }


		public String МестоПрожив { get; set; }


		public String КонтТелГор { get; set; }


		public String КонтТелефон { get; set; }


		public String ФамилияДляУвольнения { get; set; }


		public String СтраховойПолис { get; set; }


		public String НаличеДогПодряда { get; set; }


		public String ФамилияДляЗаявления { get; set; }


		public String ИмяДляЗаявления { get; set; }


		public String ОтчествоДляЗаявления { get; set; }


		public String Пол { get; set; }


		public String ФИОДатПадКому { get; set; }


		public String ДатаРожд { get; set; }


		public String Гражданин { get; set; }


		public String ПровДатыКонтр { get; set; }


		public String Иностранец { get; set; }


		public String ФамилияСтар { get; set; }


		public String ИмяСтар { get; set; }


		public String ОтчествоСтар { get; set; }


		public String ФИОСборноеСтар { get; set; }


		public String ФамилияРодПадСтар { get; set; }


		public String ИмяРодПадСтар { get; set; }


		public String ОтчествоРодПадСтар { get; set; }


		public String ФИОРодПодСтар { get; set; }


		public DateTime? ДатаИзменения { get; set; }


	    public String ФИОКотракт2020 { get; set; }


		public String Справочник { get; set; }


	//public _ЧекЛист As EntitySet(Of ЧекЛист)


	//public _ЧекЛистПродление As EntitySet(Of ЧекЛистПродление)


	//public _ДогПодряда As EntitySet(Of ДогПодряда)


	//public _ПродлКонтракта As EntitySet(Of ПродлКонтракта)

	}
}
