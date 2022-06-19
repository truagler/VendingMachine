export class OrderBlank{
	id: number;
	productId: number;
	createdDateTime: Date;
	constructor(id: number, productId: number, createdDateTime: Date) {
		this.id = id;
		this.productId = productId;
		this.createdDateTime = createdDateTime;
	}
}