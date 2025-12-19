using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace RestaurantRecApp.Providers {
  internal class RawRatingProvider {

  }
}

// CSV схема:
// 0 customer_id | 1 restaurant_link | 2 restaurant_name | 3 country | 4 city | 5 address
// 6 avg_rating | 7 price_range | 8 cuisines | 9 features | 10 rating (Label)
public class RawRating {
  [LoadColumn(0)] public int customer_id { get; set; }
  [LoadColumn(1)] public string restaurant_link { get; set; }
  [LoadColumn(2)] public string restaurant_name { get; set; }
  [LoadColumn(6)] public float avg_rating { get; set; }
  [LoadColumn(10)] public float Label { get; set; } // персоналізована оцінка
}

// Вхід/вихід для 1-го етапу (MF)
public class MFInput {
  public int customer_id { get; set; }
  public string restaurant_link { get; set; }
  public float Label { get; set; }   // не обов'язково для інференсу, але статично зручно
}
public class MFOutput {
  public float Score { get; set; }   // прогноз MF
}

// Вхід/вихід для 2-го етапу (калібрування SDCA)
public class CalibInput {
  public float MFScore { get; set; }
  public float avg_rating { get; set; }
  public float Label { get; set; } // потрібен лише на тренуванні
}
public class CalibOutput {
  public float Score { get; set; }     // фінальний прогноз
}

public class ScoredItem {
  public string Link { get; set; }
  public string Name { get; set; }
  public float Score { get; set; }
  public ScoredItem(string link, string name, float score) {
    Link = link; Name = name; Score = score;
  }
}