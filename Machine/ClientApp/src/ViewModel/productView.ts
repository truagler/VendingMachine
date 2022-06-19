import {ProductCategory} from "../Enum/ProductCategory";

export class ProductView{
	public id: number;
	public name: string;
	public countProduct: number;
	public price: number;
	public description: string;
	public category: ProductCategory;
	public isRemoved: boolean;
	constructor(id: number,
				name: string,
				countProduct: number,
				price: number,
				description: string,
				category: ProductCategory,
				isRemoved: boolean) {
		this.id = id;
		this.name = name;
		this.countProduct = countProduct;
		this.price = price;
		this.description = description;
		this.category = category;
		this.isRemoved = isRemoved;
	}
}