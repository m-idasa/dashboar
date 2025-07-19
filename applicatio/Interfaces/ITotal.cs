using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.Dto;
using infrastructure.Data;


namespace application.Interfaces;

public interface ITotal
{
    public TotalResponseDto TotalCalculate(RequestDto request);

    public List<CircleResultDto> TotalPerHourCalculate();
}