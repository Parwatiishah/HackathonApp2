using System;
using System.Collections.Generic;

namespace CollegeSoftApp.Models;

public partial class Vacancy:VacancyEdit
{
    
    public virtual User User { get; set; } = null!;
}
public partial class VacancyEdit
{
    public int Vid { get; set; }

    public string JobTitle { get; set; } = null!;

    public string JobDes { get; set; } = null!;

    public string JobRequirements { get; set; } = null!;

    public string JobLocation { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string ContactEmail { get; set; } = null!;

    public DateTime PostDate { get; set; }

    public int UserId { get; set; }

}