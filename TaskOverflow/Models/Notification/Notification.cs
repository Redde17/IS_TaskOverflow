using System;

namespace TaskOverflow.Models.Notification;

public class Notification
{
  public int id { get; set; }
  public string title { get; set; }
  public string description { get; set; }
  
  public Notification(){}

  public Notification(int id, string title, string description)
  {
    //Title: 50 caratteri
    //Description: 255 caratteri
    this.id = id;
    if (title.Length > 50) throw new FormatException("Titolo troppo lungo");
    this.title = title;
    if(description.Length > 255) throw new FormatException("Descrizione troppo lunga");
    this.description = description;
  }
}