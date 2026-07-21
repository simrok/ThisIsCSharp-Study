var GetStatistics = (List<object[]> records) =>
{
    var statistics = new Dictionary<string, int>();

    foreach (var record in records)
    {
        var (contentType, contentViews) = record switch
        {
            [_, "COMEDY", .., var views] => ("COMEDY", views),      // 범위 패턴 ..
            [_, "SF", .., var views] => ("SF", views),              // 리스트 패턴
            [_, "ACTION", .., var views] => ("ACTION", views),
            [_, .., var amount] => ("ETC", amount),
            _ => ("ETC", 0),
        };

        if (statics.ContainsKey(contentType))
            statistics[contentType] += (int)contentViews;
        else
            statistics.Add(contentType, (int)contentViews);
    }

    return statistics;
};

// 이걸 그냥 메소드로 바꾸면
// Dictionary<string, int> GetStatistics(List<object[]> records)
//{
//    var statistics = new Dictionary<string, int>();

//    ...

//    return statistics;
//}

List<object[]> MovieRecords = new List<object[]>()
{
    new object[] {0, "COMEDY", "Spy", 2015, 10_000 },
    new object[] {1, "COMEDY", "Scary Movie", 20_000 },
    new object[] {2, "SF", "Avengers: Infinite War", 100_000 },
    new object[] {3 "COMEDY", "극한직업", 25_000 },
    new object[] {4, "SF", "Star Wars",200_000 },
    new object[] {5, "ACTION", "Fast", 80_000 },
    new object[] {6, "DRAMA", "Notting Hill", 1_000 },
};

var statistics = GetStatistics(MovieRecords);

foreach(var s in statistics)
    Console.WriteLine($"{s.Key}: {s.Value}");

/* 출력결과:
COMEDY: 55000
SF: 300000
ACTION: 80000
ETC: 1000
 */