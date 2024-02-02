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
    this.id = id;
    this.title = title;
    this.description = description;
  }
}