import {CoinBlank} from "../Blank/coinBlank";
import {OrderBlank} from "../Blank/orderBlank";
import {ProductBlank} from "../Blank/productBlank";
import {CoinView} from "../ViewModel/coinView";
import {OrderView} from "../ViewModel/orderView";
import {ProductView} from "../ViewModel/productView";

export class Mapper{
	public static mapToCoinBlank(data: any): CoinBlank {
		return new CoinBlank(data.id, data.coinCategory, data.maxCoinCount, data.nowCoinCount);
	}
	
	public static mapToCoinBlanks(data: any[]): CoinBlank[]{
		if(data.length === 0) return [];
		
		return data.map(item => this.mapToCoinBlank(item));
	}

	public static mapToOrderBlank(data: any): OrderBlank {
		return new OrderBlank(data.id, data.productId, data.createdDateTime);
	}

	public static mapToOrderBlanks(data: any[]): OrderBlank[] {
		if(data.length === 0) return [];

		return data.map(item => this.mapToOrderBlank(item));
	}

	public static mapToProductBlank(data: any): ProductBlank {
		return new ProductBlank(data.id, data.name, data.countProduct, data.price, data.description, data.category, data.isRemoved);
	}

	public static mapToProductBlanks(data: any[]): ProductBlank[] {
		if(data.length === 0) return [];

		return data.map(item => this.mapToProductBlank(item));
	}
	
	public static mapToCoinView(data: any): CoinView {
		return new CoinView(data.id, data.coinCategory, data.maxCoinCount, data.nowCoinCount);
	}

	public static mapToCoinViews(data: any[]): CoinView[] {
		if(data.length === 0) return [];

		return data.map(item => this.mapToCoinView(item));
	}

	public static mapToOrderView(data: any): OrderView {
		return new OrderView(data.id, data.productId, data.createdDateTime);
	}

	public static mapToOrderViews(data: any[]): OrderView[] {
		if(data.length === 0) return [];

		return data.map(item => this.mapToOrderView(item));
	}
	
	public static mapToProductView(data: any): ProductView {
		return new ProductBlank(data.id, data.name, data.countProduct, data.price, data.description, data.category, data.isRemoved);
	}

	public static mapToProductViews(data: any[]): ProductView[] {
		if(data.length === 0) return [];

		return data.map(item => this.mapToProductBlank(item));
	}
	
	}