using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimationKamlaV1.Models
{
  public class HomeViewModel
  {
    public IEnumerable<tbl_home> post { get; set; }
    public IEnumerable<tbl_category_sub> allcategory { get; set; }
   
    //public string categoryname { get; set; }
  }
}
