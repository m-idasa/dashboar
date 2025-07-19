using domain.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Dto;

public class CircleResponseDto
{
    public string? Service { get; set; }
    public string? Client { get; set; }

    public List<CircleResultDto> Data { get; set; }
}
