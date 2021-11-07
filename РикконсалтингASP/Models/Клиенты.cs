using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.Models
{
    public partial class Клиенты
    {

		[Key]
		public int ID {get;set;} 


	public string НазвОрг {get;set;} 


	public string ФормаСобств {get;set;} 


	public string УНП {get;set;} 


	public string ФактичАдрес {get;set;} 


	public string ЮрАдрес {get;set;} 


	public string ПочтАдрес {get;set;} 


	public string КонтТелефон {get;set;} 


	public string Факс {get;set;} 


	public string ЭлАдрес {get;set;} 


	public string ДругиеКонтакты {get;set;} 


	public string Банк {get;set;} 


	public string БИКБанка {get;set;} 


	public string АдресБанка {get;set;} 


	public string Отделение {get;set;} 


	public string РасчСчетРубли {get;set;} 


	public string РасчСчетЕвро {get;set;} 


	public string РасчСчетДоллар {get;set;} 


	public string РасчСчетРоссРубли {get;set;} 


	public string ДолжнРуководителя {get;set;} 


	public string ФИОРуководителя {get;set;} 


	public string ОснованиеДейств {get;set;} 


	public string ТелРуков {get;set;} 


	public string ДолжнДопЛица {get;set;} 


	public string ФИОДопЛица {get;set;} 


	public string ТелДопЛица {get;set;} 


	public string Операционист {get;set;} 


	public string КонтТелОпер {get;set;} 


	public int ФизЛицо {get;set;} 


	public int ЮрЛицо {get;set;} 


	public string ФИОРукРодПадеж {get;set;} 


	public string ФИОРукДатПадеж {get;set;} 


	public string РукИП {get;set;} 


	public string МестоСостДляДоговора {get;set;} 

	}
}
