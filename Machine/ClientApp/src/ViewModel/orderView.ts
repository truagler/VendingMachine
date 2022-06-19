export class OrderView{
	public id: number;
	public productId: number;
	public createdDateTime: Date;
	constructor(
		id: number,
		productId: number,
		createdDateTime: Date) {
		this.id = id;
		this.productId = productId;
		this.createdDateTime = createdDateTime;
	}
}