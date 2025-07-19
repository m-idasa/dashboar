using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Dto;

public class LineResponseDto
{
    public string? Service { get; set; }
    public string? Client { get; set; }
    public List<LineResultDto> Results { get; set; }
}
