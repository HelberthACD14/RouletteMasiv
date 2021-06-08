using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
public class RouletteItem
{
    public long Id { get; set; }
    [Required]
    public bool Status { get; set; }
    public int LastNumber { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateModification { get; set; } = DateTime.Now;

}