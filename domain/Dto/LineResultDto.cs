using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsetmc.Base.Extention;

namespace domain.Dto;

public class LineResultDto
{
    public string? RName { get; set; }
    public int? RCount { get; set; }
    public DateTime DFrom { get; set; }
    public DateTime? DTo { get; set; }
    public string From { get { return DFrom.ToPersianDate(); } }
    public string? To { get { return DTo is not null ? ((DateTime)DTo).ToPersianDate() : null; } }


}
