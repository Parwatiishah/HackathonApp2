using System;
using System.Collections.Generic;

namespace CollegeSoftApp.Models;

public partial class PrograInfoView
{
    public int Pid { get; set; }

    public string Pname { get; set; } 

    public string Pdescription { get; set; } 

    public string Venue { get; set; } 

    public DateTime StartDate { get; set; }

    public string StartTime { get; set; } 

    public DateTime EndDate { get; set; }

    public string EndTime { get; set; } 

    public int UserId { get; set; }

    public string? EntryUser { get; set; }

    public DateTime CancelledDate { get; set; }

    public int CancelledId { get; set; }

    public string? CancelledBy { get; set; }
}
