interface DashboardInfo {
  MonthlyEarnings: number,
  AnnualEarnings: number,
  MemberSums: number,
  GoodsSums: number,
}

interface WeeklyEarnings {
  List: {
    DayOfWeeks: number;
    Earnings: number;
  }[]
}

interface GoodsInCategoryCount {
  List: {
    CategoryName: string;
    Count: number;
  }[]
}

interface GoodsInStocks {
  List: {
    GoodsName: string;
    Count: number;  
  }[]
}

interface MembersGrow {
  List: {
    MountsOfYear: string;
    Count: number;
  }[]
}