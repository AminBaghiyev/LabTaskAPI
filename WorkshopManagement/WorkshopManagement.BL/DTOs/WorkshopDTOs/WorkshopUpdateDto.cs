﻿namespace WorkshopManagement.BL.DTOs;

public record WorkshopUpdateDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public bool IsDeleted { get; set; }
}
