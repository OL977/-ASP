using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.Models
{
    public partial class КарточкиСотрудников
    {

		[Key]
		public int Код {get;set;} 


	public int IDСотр {get;set;} 


	public DateTime ДатаПриема {get;set;}


	public DateTime ДатаУвольнения {get;set;} 


	public string СрокКонтракта {get;set;} 


	public string ТипРаботы {get;set;} 


	public string Ставка {get;set;} 


	public string ВремяНачРаботы {get;set;} 


	public string ПродолРабДня {get;set;} 


	public string Обед {get;set;} 


	public string ОкончРабДня {get;set;} 


	public string Выходные {get;set;} 


	public string ПриказОбУвольн {get;set;} 


	public DateTime ДатаПриказаОбУвольн {get;set;} 


	public string ОснованиеУвольн {get;set;} 


	public DateTime ДатаУведомлПродКонтр {get;set;}


	public string НомерУведомлПродКонтр {get;set;} 


	public string СрокПродлКонтракта {get;set;} 


	public string ПродлКонтрС {get;set;} 


	public string ПродлКонтрПо {get;set;} 


	public string НеПродлениеКонтр {get;set;} 


	public string СрокОтветаНаУведомл {get;set;} 


	public string АдресОбъектаОбщепита {get;set;} 


	public string ПриказПродлКонтр {get;set;} 


	public string ДатаЗарплаты {get;set;} 


	public string ДатаАванса {get;set;} 


	public string ПоСовмест {get;set;} 


	public string СуммирУчет {get;set;} 


	public int НомУведИзмСрокЗарп {get;set;} 


	public string ДатаСогласияНаИзмен {get;set;} 


	public string ДатаВсуплСоглаш {get;set;} 


	public string ДатаУведом {get;set;} 


	public string ДатаПеревода {get;set;} 


	public string ДатаЗаявленияПеревода {get;set;} 


	public string ДатаПриказаПеревода {get;set;} 


	public string НомерПриказаПеревода {get;set;} 


	public string Примечание {get;set;} 


	public string НаличиеИспытСрока {get;set;} 


	public string ПериодОтпДляКонтр {get;set;} 


	public int НомерУведИзмОклада {get;set;} 


	public string ДатаУведомИзмОклада {get;set;} 

	}
}
