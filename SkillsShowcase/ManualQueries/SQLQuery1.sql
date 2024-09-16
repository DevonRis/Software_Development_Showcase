CREATE TABLE dbo.FirstQuarterRevenue (
    FirstQuarterRevenueId INT PRIMARY KEY,
    MonthRevenue INT NOT NULL,
    Month INT NOT NULL
);

INSERT INTO dbo.FirstQuarterRevenue (FirstQuarterRevenueId, MonthRevenue, Month)
VALUES 
(1, 4015, 1),
(2, 10043, 2),
(3, 7023, 3),  
(4, 9052, 4);   