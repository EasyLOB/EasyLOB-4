USE Northwind

/*
-- SELECT CategoryId,CategoryName FROM Categories ORDER BY 1

1	Beverages
2	Condiments
3	Confections
4	Dairy Products
5	Grains/Cereals
6	Meat/Poultry
7	Produce
8	Seafood
*/

UPDATE Categories SET Picture = ( SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\EasyLOB\EasyLOB-Northwind\sql\apple.png', SINGLE_BLOB) AS image ) WHERE CategoryId = 1
UPDATE Categories SET Picture = ( SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\EasyLOB\EasyLOB-Northwind\sql\apple.png', SINGLE_BLOB) AS image ) WHERE CategoryId = 2
UPDATE Categories SET Picture = ( SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\EasyLOB\EasyLOB-Northwind\sql\apple.png', SINGLE_BLOB) AS image ) WHERE CategoryId = 3
UPDATE Categories SET Picture = ( SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\EasyLOB\EasyLOB-Northwind\sql\apple.png', SINGLE_BLOB) AS image ) WHERE CategoryId = 4
UPDATE Categories SET Picture = ( SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\EasyLOB\EasyLOB-Northwind\sql\apple.png', SINGLE_BLOB) AS image ) WHERE CategoryId = 5
UPDATE Categories SET Picture = ( SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\EasyLOB\EasyLOB-Northwind\sql\apple.png', SINGLE_BLOB) AS image ) WHERE CategoryId = 6
UPDATE Categories SET Picture = ( SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\EasyLOB\EasyLOB-Northwind\sql\apple.png', SINGLE_BLOB) AS image ) WHERE CategoryId = 7
UPDATE Categories SET Picture = ( SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\EasyLOB\EasyLOB-Northwind\sql\apple.png', SINGLE_BLOB) AS image ) WHERE CategoryId = 8
