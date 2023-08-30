using Product;
using System;
namespace ProductReviewManagement
{
    class program
    {
        static void Main()
        {
            List<product> list = new List<product>();
            list.Add(new product()
            {
                productID=1,
                UserId=1,
                Rating=5,
                Review="Good",
                isLike=true
            });
            list.Add(new product()
            {
                productID = 2,
                UserId = 1,
                Rating = 3,
                Review = "Avg",
                isLike = true
            });

            list.Add(new product()
            {
                productID = 3,
                UserId = 2,
                Rating = 1,
                Review = "Bad",
                isLike = false
            });
            list.Add(new product()
            {
                productID = 4,
                UserId = 2,
                Rating = 4,
                Review = "Good",
                isLike = true
            });
            list.Add(new product()
            {
                productID = 5,
                UserId = 2,
                Rating = 1,
                Review = "Bad",
                isLike = false
            });
            list.Add(new product()
            {
                productID = 6,
                UserId = 3,
                Rating = 3,
                Review = "Avg",
                isLike = true
            });
            list.Add(new product()
            {
                productID = 7,
                UserId = 3,
                Rating = 4,
                Review = "Good",
                isLike = true
            });
            list.Add(new product()
            {
                productID = 8,
                UserId = 3,
                Rating = 2,
                Review = "Bad",
                isLike = false
            });
            list.Add(new product()
            {
                productID = 9,
                UserId = 4,
                Rating = 5,
                Review = "Good",
                isLike = true
            });
            list.Add(new product()
            {
                productID = 10,
                UserId = 4,
                Rating = 4,
                Review = "Good",
                isLike = true
            });
            list.Add(new product()
            {
                productID =11,
                UserId = 4,
                Rating = 1,
                Review = "Bad",
                isLike = false
            });
            list.Add(new product()
            {
                productID = 12,
                UserId = 5,
                Rating = 4,
                Review = "Good",
                isLike = true
            });
            list.Add(new product()
            {
                productID = 13,
                UserId = 5,
                Rating = 4,
                Review = "Good",
                isLike = true
            });
            list.Add(new product()
            {
                productID = 14,
                UserId = 6,
                Rating = 5,
                Review = "Nice",
                isLike = true
            });
            list.Add(new product()
            {
                productID = 15,
                UserId = 7,
                Rating = 3,
                Review = "Avg",
                isLike = true
            });
            operation operation = new operation();
            // operation.RetreiveTopRecords(list);
            // operation.RetreiveAllRecordsWithCondition(list);
            // operation.UsingGroupBy(list);
            // operation.RetreiveProductIdAndReview(list);
            // operation.skiptoprecords(list);
            // operation.AddDataToDataTable(list);
            //operation.RetreiveisLikeMethodisTrue(list);
            // operation.RetreiveRatingisAvg(list);
            // operation.RetreiveDataReviewisNice(list);
            operation.AddvaluesinTableList(list);
        }
    }
}