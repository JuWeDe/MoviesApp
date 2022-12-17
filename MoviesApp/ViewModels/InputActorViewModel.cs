using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.ViewModels;

public class InputActorViewModel
{
    public int Id { get; set; }
    [Required] [ValidActorsNameLength(4)] public string Name { get; set; }
    [Required] [ValidActorsNameLength(4)] public string Surname { get; set; }

    [DataType(DataType.Date)] [Required] public DateTime DateOfBirth { get; set; }
}