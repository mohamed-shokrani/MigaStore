﻿namespace SharedProject.Models;

public class Model
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }

}
