import {CoinCategory} from "../Enum/CoinCategory";
import {ProductCategory} from "../Enum/ProductCategory";

export class Language{
	public static toCoinCategory(category: CoinCategory){
		switch (category){
			case CoinCategory.one: return "Один"; 
			case CoinCategory.two: return "Два"; 
			case CoinCategory.five: return "Пять"; 
			case CoinCategory.ten: return "Десять"; 
		}
	}
	
	public static toProductCategory(category: ProductCategory){
		switch (category){
			case ProductCategory.food: return "Еда"; 
			case ProductCategory.drink: return "Напитки"; 
			case ProductCategory.item: return "Сувениры"; 
		}
	}
}