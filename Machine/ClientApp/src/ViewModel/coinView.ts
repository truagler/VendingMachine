import {CoinCategory} from "../Enum/CoinCategory";

export class CoinView{
	public id: number;
	public coinCategory: CoinCategory;
	public maxCoinCount: number;
	public nowCoinCount: number;
	constructor(id: number, coinCategory: CoinCategory, maxCoinCount: number, nowCoinCount: number) {
		this.id = id;
		this.coinCategory = coinCategory;
		this.maxCoinCount = maxCoinCount;
		this.nowCoinCount = nowCoinCount;
	}
}