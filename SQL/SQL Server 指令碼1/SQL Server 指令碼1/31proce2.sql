SELECT          Products.ProductName, year(Orders.OrderDate) as yy, month(Orders.OrderDate) as mm , day(Orders.OrderDate) as dd, [Order Details].UnitPrice, [Order Details].Quantity, [Order Details].Discount, 
                            [Order Details].ProductID
FROM              Orders INNER JOIN
                            [Order Details] ON Orders.OrderID = [Order Details].OrderID INNER JOIN
                            Products ON [Order Details].ProductID = Products.ProductID
ORDER BY   [Order Details].ProductID