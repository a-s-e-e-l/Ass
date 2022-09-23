CREATE VIEW [CSV] ASselect R.Name RestaurantName ,	COUNT(RC.Cid) NumberOfOrderedCustomer ,	SUM(RM.PriceInUsd) ProfitInUsd ,	SUM(RM.PriceInNis) ProfitInNis ,	m.mealName TheBestSellingMeal ,	N.NameCustumer MostPurchasedCustomer	from resCustomer RC	join restaurantMenu RM on RC.Rid =RM.Id	join restaurant R on RM.Rid = R.Id	join [meal] m on m.resturantName=R.Name	join [CustomerName] N on N.resturantName=R.Name	group by (R.Name),(m.mealName),(N.NameCustumer)CREATE VIEW [allNumberOfOrder] AS	select R.Name RName,RM.MealName MName, COUNT(RC.Rid) numberOfOrder	from resCustomer RC 	join restaurantMenu RM on RC.Rid =RM.Id	join restaurant R on RM.Rid = R.Id	group by RM.MealName,R.Name;CREATE VIEW [all] AS	select distinct RName , MAX(numberOfOrder)TheBestSellingMeal 	from [allNumberOfOrder]	group by RName;	create view [meal]as	select b.RName resturantName,a.MName mealName	from [all] b 	join allNumberOfOrder a on a.numberOfOrder=b.TheBestSellingMealCREATE VIEW [allNumberOfCustomer] AS select R.Name RName,CONCAT(C.FirstName, ' ',C.LastName)FName, COUNT(RC.Rid) numberOfCustomer	from resCustomer RC 		join customer C on RC.Cid =C.Id		join restaurantMenu RM on RC.Rid =RM.Id		join restaurant R on RM.Rid = R.Id		group by CONCAT(C.FirstName, ' ',C.LastName),(R.Name)		drop view [CustomerName]CREATE VIEW [allCustomer] AS	select RName , MAX(numberOfCustomer)MostPurchasedCustomer 	from [allNumberOfCustomer]	group by RName;		create view [CustomerName]as	select b.RName resturantName,a.FName NameCustumer	from [allCustomer] b 	join [allNumberOfCustomer] a on a.numberOfCustomer=b.MostPurchasedCustomer