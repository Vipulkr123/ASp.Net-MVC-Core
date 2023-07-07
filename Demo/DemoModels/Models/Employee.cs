using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoModels.Models;

public class Employee
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	[Required]
	[StringLength(50)]
	[MaxLength(50, ErrorMessage = "Name should be max 50 charcter only!")]
	public string Name { get; set; }

	[Required]
	[Column(TypeName = "Date")]
	[Display(Name = "JoiningDate")]
    //[Range(typeof(DateTime), "01/10/2008", "07/07/2023",ErrorMessage = "Date should be between 01/10/2008 - 07/07/2023")]
    [DataType(DataType.Date, ErrorMessage = "Date is Required"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime DOB { get; set; }

	public int? Age { get; set; }
}