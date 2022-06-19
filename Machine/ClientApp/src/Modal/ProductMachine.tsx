import React, {Component} from "react";
import {Modal, ModalBody, ModalFooter, ModalHeader} from "reactstrap";
import {CoinView} from "../ViewModel/coinView";
import {ProductView} from "../ViewModel/productView";
import {Language} from "../Language/Language";
import {CoinCategory} from "../Enum/CoinCategory";
import {Mapper} from "../Mapper/Mapper";


export interface Props{
	isShown: boolean;
	hide: () => void;
	coins: CoinView[];
	product: ProductView;
	getProducts: () => void;
	getCoins: () => void;
}

type State = {
	moneyCount: number;
}

export class ProductMachine extends Component<Props, State>{
	constructor(props: Props) {
		super(props);
		
		this.state = {
			moneyCount: 0
		}
	}

	async buyProduct(id: number){
		
		if(this.props.product.price < this.state.moneyCount){
			return alert("У вас недостаточно средств!")
		}
		
		await fetch('buyproduct', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			},
			body: JSON.stringify(id)
		});
		this.setState({moneyCount: 0})
		this.props.hide();
		await this.props.getProducts();
	}

	async minusCoinCount(id: number, nowCoinCount: number, maxCoinCount: number) {
		
		if(nowCoinCount >= maxCoinCount){
			return alert("Допустимое количество монет, попробуйте другую монету")
		}
		
		const response = await fetch('getcoin?coinId=' + id.toString());
		
		const request = Mapper.mapToCoinView(response);
		
		let moneyNow = 0;
		
		if(request.coinCategory == CoinCategory.one){
			moneyNow = 1;
		}
		
		if(request.coinCategory == CoinCategory.two){
			moneyNow = 2;
		}
		
		if(request.coinCategory == CoinCategory.five){
			moneyNow = 5;
		}
		
		if(request.coinCategory == CoinCategory.ten){
			moneyNow = 10;
		}
		
		const moneyCount = this.state.moneyCount + moneyNow;
			
		await fetch('updatecoinnow?coinId=', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			},
			body: JSON.stringify(id)
		});
		
		this.setState({ moneyCount: moneyCount })
		
		await this.props.getCoins();
	}

	render() {
		return (
			<div>
				<Modal size="lg"
					   aria-labelledby="contained-modal-title-vcenter"
					   isOpen={this.props.isShown}
					   fade={false}
				>
					<ModalHeader>
						<h1>Покупка {this.props.product.name}</h1>
					</ModalHeader>
					<ModalBody>
						<p>Количество денег сейчас: {this.state.moneyCount}</p>
						<p>Стоимость: <b>P{this.props.product.price}</b></p>
						<p>Стоимость: P{this.props.product.description}</p>
						<div className="btn-group" role="group">
							{this.props.coins.map(coin =>
								<button onClick={() => this.minusCoinCount(coin.id, coin.nowCoinCount, coin.maxCoinCount)} value={coin.coinCategory == CoinCategory.one ? 1 : coin.coinCategory == CoinCategory.two ? 2 : coin.coinCategory == CoinCategory.five ? 5 : 10} type="button" className="btn btn-secondary">{Language.toCoinCategory(coin.coinCategory)}</button>
							)}
						</div>
					</ModalBody>
					<ModalFooter>
						<button onClick={() => this.buyProduct(this.props.product.id)} className="btn btn-success">Купить продукт</button>
						<button onClick={() => this.props.hide()} className="btn btn-danger">Выйти</button>
					</ModalFooter>
				</Modal>
			</div>
		);
	}
}