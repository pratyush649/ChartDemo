using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChartDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChartDemo.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        private MyDbContext _context;
        public ChartController(MyDbContext context)
        {
            this._context = context;
        }
        public IActionResult Data()
        {
            var result = _context.SaleOrder
                        .GroupBy(x => new { group = x.Zone })
                        .Select(group => new{
                            zone = group.Key.group,
                            count = group.Count()
                        }).OrderByDescending(o => o.count).ToList();
            var labels = result.Select(x => x.zone).ToArray();
            var Values = result.Select(x => x.count).ToArray();
            var max = Values[0];
            List<object> list1 = new List<object>();
            list1.Add(labels);
            list1.Add(Values);
            list1.Add(max);
            return Json(list1);
            
        }
    }
}