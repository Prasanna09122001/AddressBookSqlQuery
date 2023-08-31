using Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
     class operation
    {
        DataTable table = new DataTable();
        public void RetreiveTopRecords(List<product> list)
        {
            /*  var result = list.Where(x => x.Rating == 5).Take(3);
              Display(result.ToList());*/
            var result = (from s in list
                          orderby s.Rating descending
                          select s).Take(3);
           Display(result.ToList());
        }
        public void RetreiveAllRecordsWithCondition(List<product> list)
        {
            var result = list.Where(x => x.Rating > 3 && (x.productID == 1 || x.productID == 4 || x.productID == 9));
            Display(result.ToList());
        }
        public void UsingGroupBy(List<product> list)
        {
            var result = list.GroupBy(x => x.productID).Select(x => new { ProductID = x.Key, Count = x.Count()});
                foreach(var data in result)
            {
                Console.WriteLine(data.ProductID+" "+data.Count);
            }
        }
        public void RetreiveProductIdAndReview(List<product> list)
        {
            var result = list.Select(x => new { productID = x.productID, Review = x.Review });
            foreach(var data in result)
            {
                Console.WriteLine(data.productID+" "+data.Review);
            }
        }
        public void skiptoprecords(List<product> list)
        {
            var result = list.Skip(5);
            Display(result.ToList());
        }
        public void AddDataToDataTable(List<product> list)
        {
            table.Columns.Add("ProductId").DataType = typeof(Int32);
            table.Columns.Add("UserId").DataType = typeof(Int32);
            table.Columns.Add("Rating").DataType = typeof(Int32);
            table.Columns.Add("Review").DataType = typeof(string);
            table.Columns.Add("Islike").DataType = typeof(bool);
            {
                foreach(var data in list)
                {
                    table.Rows.Add(data.productID, data.UserId, data.Rating, data.Review, data.isLike);
                }
                foreach(var item in table.AsEnumerable())
                {
                    Console.WriteLine(item.Field<int>("ProductId")+" "+item.Field<int>("UserID")+" "+item.Field<int>("Rating")+" "+item.Field<string>("Review")+" "+item.Field<bool>("isLike"));
                }
            }
        }
        public void Display(List<product> list)
        {
            foreach(var data in list)
            {
                Console.WriteLine(data.productID+" "+data.UserId+" "+data.Review+" "+data.Rating+" "+data.isLike);
            }
        }
        public void RetreiveisLikeMethodisTrue(List<product> list)
        {
            /*var result = list.Where(x => x.isLike == true);
            Display(result.ToList());*/
            var result = table.AsEnumerable().Where(x => x.Field<bool>("IsLike").Equals(true));
            foreach (var item in result.AsEnumerable())
            {
                Console.WriteLine(item.Field<int>("ProductId") + " " + item.Field<int>("UserID") + " " + item.Field<int>("Rating") + " " + item.Field<string>("Review") + " " + item.Field<bool>("isLike"));
            }

        }
        public void RetreiveRatingisAvg(List<product> list)
        {
            var result = list.Average(x => x.Rating);
            Console.WriteLine(result);
        }
        public void RetreiveDataReviewisNice(List<product> list)
        {
            var result = list.Where(x => x.Review == "Nice");
            Display(result.ToList());
        }
        public void AddvaluesinTableList(List<product> list)
        {
            list.Add(new product(){productID = 16,UserId = 10,Rating = 3,Review = "Avg",isLike = true});
            list.Add(new product() { productID = 17, UserId = 10, Rating = 5, Review = "Nice", isLike = true });
            list.Add(new product() { productID = 18, UserId = 10, Rating = 4, Review = "Good", isLike = true });
            list.Add(new product() { productID = 19, UserId = 10, Rating = 1, Review = "Bad", isLike = false });
            list.Add(new product() { productID = 20, UserId = 10, Rating = 2, Review = "Bad", isLike = false });
            var result = list.Where(x => x.UserId == 10).OrderBy(x=>x.Rating);
            Display(result.ToList());
        }
    }
}
