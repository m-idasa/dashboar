using domain.Dto;
using infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interfaces;

public interface ILine
{
    public LineResponseDto LineCalculate(RequestDto request);
}
